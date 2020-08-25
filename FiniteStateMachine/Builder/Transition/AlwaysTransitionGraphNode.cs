using XNode;

namespace Planilo.FSM.Builder
{
    [CreateNodeMenu("FSM/Transitions/Always")]
    public class AlwaysTransitionGraphNode : Node
    {
        public FiniteStateMachineTransition<T> Build<T>(int targetIndex)
        {
            return new FiniteStateMachineTransition<T>()
            {
                Condition = (T agent) => true,
                TargetState = targetIndex
            };
        }
    }
}