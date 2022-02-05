using System;
using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;

namespace PlaniloSamples.FSM
{
    public static class AlarmIsRaisedTransition
    {
        public static bool Condition(Gatherer agent)
        {
            return agent.World.Alarm;
        }

        public static bool InversedCondition(Gatherer agent)
        {
            return agent.World.Alarm == false;
        }
    }

    [CreateNodeMenu("PlaniloSamples/FSM/Transitions/AlarmIsRaised")]
    public class AlarmIsRaisedTransitionGraphNode : FiniteStateMachineTransitionGraphNode
    {
        public bool Inversed;

        public override FiniteStateMachineTransition<T> Build<T>(int targetIndex)
        {
            var transition = new FiniteStateMachineTransition<Gatherer>
            {
                Condition = Inversed ?
                    (Func<Gatherer, bool>)AlarmIsRaisedTransition.InversedCondition : AlarmIsRaisedTransition.Condition,
                TargetState = targetIndex
            };
            return transition as FiniteStateMachineTransition<T>;
        }
    }
}