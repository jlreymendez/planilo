using Planilo;
using Planilo.BT;
using Planilo.BT.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace PlaniloSamples.BT
{
    public class GathererBTDebugger : MonoBehaviour, IAIBehaviourDebugger<BehaviourTreeGraph, BehaviourTreeState>
    {
    #if UNITY_EDITOR
        public GatherersManager Manager { private get; set; }
        public int Index { private get; set; }

        public BehaviourTreeState GetState()
        {
            return Manager.GetGathererState(Index);
        }

        public BehaviourTreeGraph GetBehaviour()
        {
            return Manager.GathererBehaviour;
        }
    #endif
    }
}