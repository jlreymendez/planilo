using Planilo;
using UnityEngine;

namespace PlaniloSamples.Common
{
    public class BehaviourDebugger<TBehaviourGraph, TBehaviourState> : MonoBehaviour, IAIBehaviourDebugger<TBehaviourGraph, TBehaviourState>
    {
    #if UNITY_EDITOR
        public IBehaviourManager<TBehaviourGraph, TBehaviourState> Manager { private get; set; }
        public int Index { private get; set; }

        public TBehaviourState GetState()
        {
            return Manager.GetAgentState(Index);
        }

        public TBehaviourGraph GetBehaviour()
        {
            return Manager.BehaviourGraph;
        }
    #endif

    }
}