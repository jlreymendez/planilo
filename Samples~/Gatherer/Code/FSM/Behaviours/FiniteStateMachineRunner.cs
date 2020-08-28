using Planilo;
using Planilo.FSM;
using Planilo.FSM.Builder;
using UnityEngine;

namespace PlaniloSamples.FSM
{
    public class FiniteStateMachineRunner<T> : MonoBehaviour, IAIBehaviourDebugger<FiniteStateMachineGraph, FiniteStateMachineRuntimeState>
    {
        #region Protected
        protected T agent;
        #endregion

        #region Private
        [SerializeField] FiniteStateMachineGraph behaviourDefinition;
        FiniteStateMachineRuntimeState state;
        IAIBehaviour<T, FiniteStateMachineRuntimeState> behaviour;

        void Awake()
        {
            behaviour = behaviourDefinition.Build<T>();
            agent = default;
            state = behaviour.Initialize(ref agent);
        }

        void Update()
        {
            behaviour.Run(ref agent, ref state);
        }
        #endregion

    #if UNITY_EDITOR
        #region Editor
        public FiniteStateMachineRuntimeState GetState()
        {
            return state;
        }

        public FiniteStateMachineGraph GetBehaviour()
        {
            return behaviourDefinition;
        }
        #endregion
    #endif
    }
}