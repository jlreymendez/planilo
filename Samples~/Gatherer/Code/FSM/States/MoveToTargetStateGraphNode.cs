using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace PlaniloSamples.FSM
{
    public class MoveToTargetState : FiniteStateMachineState<Gatherer>
    {
        public override void OnTick(ref Gatherer agent)
        {
            var direction = Vector3.Normalize(agent.Target - agent.Transform.position);
            agent.Transform.position += direction * (Time.deltaTime * agent.Speed);
        }
    }

    [CreateNodeMenu("PlaniloSamples/FSM/States/MoveToTarget")]
    public class MoveToTargetStateGraphNode : FiniteStateMachineStateGraphNode
    {
        protected override FiniteStateMachineState<T> ProtectedBuild<T>()
        {
            return new MoveToTargetState() as FiniteStateMachineState<T>;
        }
    }
}