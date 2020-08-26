using XNode;

namespace Planilo.FSM.Builder
{
    [CreateNodeMenu("Planilo/FSM/Transitions/Always")]
    public class AlwaysTransitionGraphNode : FiniteStateMachineTransitionGraphNode
    {
        public override FiniteStateMachineTransition<T> Build<T>(int targetIndex)
        {
            return new FiniteStateMachineTransition<T>()
            {
                Condition = (T agent) => true,
                TargetState = targetIndex
            };
        }
    }
}