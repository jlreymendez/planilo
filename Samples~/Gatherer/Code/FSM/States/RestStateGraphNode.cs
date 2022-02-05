using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace PlaniloSamples.FSM
{
    public class RestState : FiniteStateMachineState<Gatherer>
    {
        public override void OnEnter(ref Gatherer agent)
        {
            agent.LastRest = Time.time;
        }

        public override void OnTick(ref Gatherer agent) {}

        public override void OnExit(ref Gatherer agent)
        {
            agent.LastRest = Time.time;
        }
    }

    [CreateNodeMenu("PlaniloSamples/FSM/States/Rest")]
    public class RestStateGraphNode : FiniteStateMachineStateGraphNode
    {
        protected override FiniteStateMachineState<T> ProtectedBuild<T>()
        {
            return new RestState() as FiniteStateMachineState<T>;
        }
    }
}