using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace PlaniloSamples.FSM
{
    public static class HasRestedTransition
    {
        public static bool Condition(Gatherer agent)
        {
            return Time.time - agent.LastRest >= agent.RestTime;
        }
    }

    [CreateNodeMenu("PlaniloSamples/FSM/Transitions/HasRested")]
    public class HasRestedTransitionGraphNode : FiniteStateMachineTransitionGraphNode
    {
        public override FiniteStateMachineTransition<T> Build<T>(int targetIndex)
        {
            var transition = new FiniteStateMachineTransition<Gatherer>
            {
                Condition = HasRestedTransition.Condition,
                TargetState = targetIndex
            };
            return transition as FiniteStateMachineTransition<T>;
        }
    }
}