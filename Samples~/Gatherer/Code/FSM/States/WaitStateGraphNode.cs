using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;

namespace PlaniloSamples.FSM
{
    public class WaitState : FiniteStateMachineState<Gatherer>
    {
        public override void OnTick(ref Gatherer agent) {}
    }

    [CreateNodeMenu("PlaniloSamples/FSM/States/Wait")]
    public class WaitStateGraphNode : FiniteStateMachineStateGraphNode
    {
        protected override FiniteStateMachineState<T> ProtectedBuild<T>()
        {
            return new WaitState() as FiniteStateMachineState<T>;
        }
    }
}