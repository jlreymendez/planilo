using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace PlaniloSamples.FSM
{
    public class PickResourceState : FiniteStateMachineState<Gatherer>
    {
        public override void OnTick(ref Gatherer agent)
        {
            if (Vector3.Distance(agent.Transform.position, agent.Resource.transform.position) <= agent.Reach)
            {
                agent.Resource.Pick();
            }
        }
    }

    [CreateNodeMenu("PlaniloSamples/FSM/States/PickResource")]
    public class PickResourceStateGraphNode : FiniteStateMachineStateGraphNode
    {
        protected override FiniteStateMachineState<T> ProtectedBuild<T>()
        {
            return new PickResourceState() as FiniteStateMachineState<T>;
        }
    }
}