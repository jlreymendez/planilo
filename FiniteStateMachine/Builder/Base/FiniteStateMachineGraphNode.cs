using XNode;

namespace Planilo.FSM.Builder
{
    public abstract class FiniteStateMachineGraphNode : Node
    {
        public override object GetValue(NodePort port) => null;
    }
}