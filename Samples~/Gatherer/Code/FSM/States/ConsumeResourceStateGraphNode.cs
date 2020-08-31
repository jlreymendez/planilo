using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace PlaniloSamples.FSM
{
    public class ConsumeResourceState : FiniteStateMachineState<Gatherer>
    {
        public override void OnTick(ref Gatherer agent)
        {
            if (agent.Resource != null)
            {
                agent.Resource.Consume();
                agent.Resource = null;
            }
        }
    }

    [CreateNodeMenu("PlaniloSamples/FSM/States/ConsumeResource")]
    public class ConsumeResourceStateGraphNode : FiniteStateMachineStateGraphNode
    {
        protected override FiniteStateMachineState<T> ProtectedBuild<T>()
        {
            return new ConsumeResourceState() as FiniteStateMachineState<T>;
        }
    }
}