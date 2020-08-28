using System;
using System.Collections;
using System.Collections.Generic;
using Planilo;
using Planilo.BT;
using Planilo.BT.Builder;
using PlaniloSamples.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PlaniloSamples.BT
{
    public class GatherersManager : MonoBehaviour
    {
        [SerializeField] GameObject gathererPrefab;
        [SerializeField] int gatherersCount;
        [SerializeField] BehaviourTreeGraph behaviourDefinition;

        [Header("Gatherer Stats")]
        [SerializeField] float speed;
        [SerializeField] float reach;
        [SerializeField] float workTime;
        [SerializeField] float restTime;

        IAIBehaviour<Gatherer, BehaviourTreeState> behaviourTree;
        BehaviourTreeState[] gathererStates;
        Gatherer[] gatherers;
        GameObject[] gathererGos;

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
            var debugger = go.GetComponent<GathererBTDebugger>();
            if (debugger)
            {
                debugger.Manager = this;
                debugger.Index = index;
            }
        #endif
        }

        void InitializeBehaviours()
        {
            gathererStates = new BehaviourTreeState[gatherersCount];
            behaviourTree = behaviourDefinition.Build<Gatherer>();
            for (var i = 0; i < gatherersCount; i++)
            {
                gathererStates[i] = behaviourTree.Initialize(ref gatherers[i]);
            }
        }

        void Update()
        {
            var resources = FindObjectsOfType<Resource>();
            for (var i = 0; i < gatherersCount; i++)
            {
                gatherers[i].World.Resources = resources;
                behaviourTree.Run(ref gatherers[i], ref gathererStates[i]);
            }
        }

    #if UNITY_EDITOR
        public BehaviourTreeGraph GathererBehaviour => behaviourDefinition;

        public BehaviourTreeState GetGathererState(int index)
        {
            return gathererStates.Length > index ? gathererStates[index] : default;
        }
    #endif
    }
}