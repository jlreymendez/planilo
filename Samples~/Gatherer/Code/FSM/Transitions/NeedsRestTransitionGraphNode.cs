using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace PlaniloSamples.FSM
{
    public static class NeedsRestTransition
    {
        public static bool Condition(Gatherer agent)
        {
            return Time.time - agent.LastRest >= agent.WorkTime;
        }
    }

    [CreateNodeMenu("PlaniloSamples/FSM/Transitions/NeedsRest")]
    public class NeedsRestTransitionGraphNode : FiniteStateMachineTransitionGraphNode
    {
        public override FiniteStateMachineTransition<T> Build<T>(int targetIndex)
        {
            var transition = new FiniteStateMachineTransition<Gatherer>
            {
                Condition = NeedsRestTransition.Condition,
                TargetState = targetIndex
            };
            return transition as FiniteStateMachineTransition<T>;
        }
    }
}