using Planilo;
using Planilo.BT;
using Planilo.BT.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace PlaniloSamples.BT
{
    public class GathererBTRunner : MonoBehaviour,
        // note: This is only required for debugging the tree inside the planilo graph tool
        IAIBehaviourDebugger<BehaviourTreeGraph, BehaviourTreeState>
    {
        [Header("General")]
        public BehaviourTreeGraph BehaviourDefinition;

        [Header("Sample 01")]
        public float Speed;
        public float Reach;

        [Header("Sample 02")]
        public float WorkTime;
        public float RestTime;

        Gatherer agent = default;
        BehaviourTreeState behaviourTreeState = default;
        IAIBehaviour<Gatherer, BehaviourTreeState> behaviourTree = default;

        void Awake()
        {
            behaviourTree = BehaviourDefinition.Build<Gatherer>();
            behaviourTreeState = behaviourTree.Initialize(ref agent);
        }

        void Start()
        {
            agent.Id = GetInstanceID();
            agent.World.Home = FindObjectOfType<Home>().transform.position;
            agent.Speed = Speed;
            agent.Reach = Reach;
            agent.Transform = transform;
            agent.LastRest = Time.time;
            agent.WorkTime = WorkTime;
            agent.RestTime = RestTime;
        }

        void Update()
        {
            // Update all agent sensors
            agent.World.Resources = FindObjectsOfType<Resource>();
            // Execute behaviour tree.
            behaviourTree.Run(ref agent, ref behaviourTreeState);
        }

    #if UNITY_EDITOR
        #region Editor
        public BehaviourTreeState GetState()
        {
            return behaviourTreeState;
        }

        public BehaviourTreeGraph GetBehaviour()
        {
            return BehaviourDefinition;
        }
        #endregion
    #endif
    }
}
