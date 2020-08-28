using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace PlaniloSamples.FSM
{
    public class GathererFSMRunner : BehaviourRunner<FiniteStateMachineGraph, FiniteStateMachineRuntimeState, Gatherer>
    {
        [Header("Sample 01")]
        public float Speed;
        public float Reach;

        [Header("Sample 02")]
        public float WorkTime;
        public float RestTime;

        protected override void UpdateWorldState()
        {
            agent.World.Resources = FindObjectsOfType<Resource>();
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
    }
}