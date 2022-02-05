using UnityEngine;
using XNode;

namespace Planilo.FSM.Builder
{
    [NodeTint("#6b532e")]
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