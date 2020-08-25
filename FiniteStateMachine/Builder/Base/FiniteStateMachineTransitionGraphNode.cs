using UnityEngine;
using XNode;

namespace Planilo.FSM.Builder
{
    [NodeTint("#2e4e6b")]
    public abstract class FiniteStateMachineTransitionGraphNode : FiniteStateMachineGraphNode
    {
        public abstract FiniteStateMachineTransition<T> Build<T>(int targetIndex);

        public FiniteStateMachineStateGraphNode GetTransitionState()
        {
            var port = GetOutputPort("target");
            return (FiniteStateMachineStateGraphNode) port?.Connection?.node;
        }

        [SerializeField, Input] FiniteStateMachineConnectionToTransition source;
        [SerializeField, Output] FiniteStateMachineConnectionToState target;
    }
}