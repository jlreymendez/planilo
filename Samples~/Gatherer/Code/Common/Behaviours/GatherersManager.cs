using System.Collections;
using System.Collections.Generic;
using Planilo;
using UnityEngine;

namespace PlaniloSamples.Common
{
    public class GatherersManager<TBehaviourGraph, TBehaviourState> : MonoBehaviour, IBehaviourManager<TBehaviourGraph, TBehaviourState>
        where TBehaviourGraph : IAIBehaviourBuilder<TBehaviourState>
    {
        [SerializeField] GameObject gathererPrefab = default;
        [SerializeField] int gatherersCount = default;
        [SerializeField] TBehaviourGraph behaviourDefinition = default;

        [Header("Gatherer Stats")]
        [SerializeField] float speed = 0.5f;
        [SerializeField] float reach = 0.05f;
        [SerializeField] float workTime = 24f;
        [SerializeField] float restTime = 8f;

        IAIBehaviour<Gatherer, TBehaviourState> behaviourTree;
        TBehaviourState[] gathererStates;
        Gatherer[] gatherers;
        GameObject[] gathererGos;
        bool alarm;

        IEnumerator Start()
        {
            enabled = false;
            var homeSpawn = WaitForHomeSpawn();
            yield return homeSpawn;
            SpawnGatherers(homeSpawn.Current);
            InitializeBehaviours();
            enabled = true;
        }

        IEnumerator<Home> WaitForHomeSpawn()
        {
            Home home = null;
            while (home == null)
            {
                home = FindObjectOfType<Home>();
                yield return null;
            }

            yield return home;
        }

        void SpawnGatherers(Home home)
        {
            gatherers = new Gatherer[gatherersCount];
            var homePosition = home.transform.position;
            // Spawn game objects.
            for (var i = 0; i < gatherersCount; i++)
            {
                var rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
                var position = new Vector3(Random.Range(0f, 0.3f), 0, 0);
                var go = Instantiate(gathererPrefab, rotation * position, Quaternion.identity);
                InitializeGatherer(i, go, homePosition);
            }
        }

        void InitializeGatherer(int index, GameObject go, Vector3 homePosition)
        {
            ref var gatherer = ref gatherers[index];
            gatherer.Id = index + 1;
            gatherer.World.Home = homePosition;
            gatherer.Transform = go.transform;
            gatherer.Speed = speed;
            gatherer.Reach = reach;
            gatherer.LastRest = Time.time;
            gatherer.WorkTime = workTime;
            gatherer.RestTime = restTime;

        #if UNITY_EDITOR
            var debugger = go.GetComponent<BehaviourDebugger<TBehaviourGraph, TBehaviourState>>();
            if (debugger != null)
            {
                debugger.Manager = this;
                debugger.Index = index;
            }
        #endif
        }

        void InitializeBehaviours()
        {
            gathererStates = new TBehaviourState[gatherersCount];
            behaviourTree = behaviourDefinition.Build<Gatherer>();
            for (var i = 0; i < gatherersCount; i++)
            {
                gathererStates[i] = behaviourTree.Initialize(ref gatherers[i]);
            }
        }

        void Update()
        {
            // Toggle alarm in world state.
            if (Input.GetKeyUp(KeyCode.A))
            {
                alarm = !alarm;
            }
            // Find all available resources
            var resources = FindObjectsOfType<Resource>();
            // Run behaviours and update the world state.
            for (var i = 0; i < gatherersCount; i++)
            {
                gatherers[i].World.Alarm = alarm;
                gatherers[i].World.Resources = resources;
                behaviourTree.Run(ref gatherers[i], ref gathererStates[i]);
            }
        }

    #if UNITY_EDITOR
        public TBehaviourGraph BehaviourGraph => behaviourDefinition;

        public TBehaviourState GetAgentState(int index)
        {
            return gathererStates.Length > index ? gathererStates[index] : default;
        }
    #endif
    }
}