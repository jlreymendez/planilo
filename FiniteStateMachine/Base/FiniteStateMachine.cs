using System;

namespace Planilo.FSM
{
    public class FiniteStateMachine<T> : IAIBehaviour<T, FiniteStateMachineRuntimeState>
    {
        #region Public
        public FiniteStateMachine(FiniteStateMachineState<T>[] states)
        {
            this.states = states;
        }

        public FiniteStateMachineRuntimeState Initialize(ref T agent)
        {
            return FiniteStateMachineRuntimeState.EntryState;
        }

        public void Run(ref T agent, ref FiniteStateMachineRuntimeState state)
        {
            var currentState = states[state.CurrentState];
            if (state.CurrentState != state.LastState)
            {
                currentState.OnEnter(ref agent);
                state.LastState = state.CurrentState;
            }

            currentState.OnTick(ref agent);

            for (var i = 0; i < currentState.Transitions.Length; i++)
            {
                if (currentState.Transitions[i].Condition(agent))
                {
                    state.CurrentState = currentState.Transitions[i].TargetState;
                    break;
                }
            }

            if (state.CurrentState != state.LastState)
            {
                currentState.OnExit(ref agent);
            }
        }
        #endregion

        #region Private
        FiniteStateMachineState<T>[] states;
        #endregion
    }
}