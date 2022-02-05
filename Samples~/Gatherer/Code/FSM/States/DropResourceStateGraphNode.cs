using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;

namespace PlaniloSamples.FSM
{
    public class DropResourceState : FiniteStateMachineState<Gatherer>
    {
        public override void OnEnter(ref Gatherer agent)
        {
            if (agent.Resource != null && agent.Resource.CarrierId == agent.Id)
            {
                agent.Resource.Drop(agent.Transform.position);
                agent.Resource.CarrierId = 0;
                agent.Resource = null;
            }
        }

        public override void OnTick(ref Gatherer agent) { }
    }

    [CreateNodeMenu("PlaniloSamples/FSM/States/DropResource")]
    public class DropResourceStateGraphNode : FiniteStateMachineStateGraphNode
    {
        protected override FiniteStateMachineState<T> ProtectedBuild<T>()
        {
            return new DropResourceState() as FiniteStateMachineState<T>;
        }
    }
}