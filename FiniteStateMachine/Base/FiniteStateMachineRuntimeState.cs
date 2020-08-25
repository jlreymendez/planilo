namespace Planilo.FSM
{
    public struct FiniteStateMachineRuntimeState
    {
        public int CurrentState;
        public int LastState;

        public static FiniteStateMachineRuntimeState EntryState => new FiniteStateMachineRuntimeState
            {
                CurrentState = 0,
                LastState = -1
            };
    }
}