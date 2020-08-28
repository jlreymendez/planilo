using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace PlaniloSamples.FSM
{
    public static class FoundResourceTransition
    {
        public static bool Condition(Gatherer agent)
        {
            return agent.Resource != null;
        }
    }

    [CreateNodeMenu("PlaniloSamples/FSM/Transitions/FoundResource")]
    public class FoundResourceTransitionGraphNode : FiniteStateMachineTransitionGraphNode
    {
        public override FiniteStateMachineTransition<T> Build<T>(int targetIndex)
        {
            var transition = new FiniteStateMachineTransition<Gatherer>
            {
                Condition = FoundResourceTransition.Condition,
                TargetState = targetIndex
            };
            return transition as FiniteStateMachineTransition<T>;
        }
    }
}