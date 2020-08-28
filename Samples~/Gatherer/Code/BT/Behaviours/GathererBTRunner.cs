using Planilo.BT;
using Planilo.BT.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace PlaniloSamples.BT
{
    public class GathererBTRunner : BehaviourRunner<BehaviourTreeGraph, BehaviourTreeState, Gatherer>
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
