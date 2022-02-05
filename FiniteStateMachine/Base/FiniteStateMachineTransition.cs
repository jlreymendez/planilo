using System;

namespace Planilo.FSM
{
    public class FiniteStateMachineTransition<T>
    {
        public Func<T, bool> Condition;
        public int TargetState;
    }
}