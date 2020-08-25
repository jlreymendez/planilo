namespace Planilo.FSM
{
    public abstract class FiniteStateMachineState<T>
    {
        #region Public
        public virtual void OnEnter(ref T agent) {}

        public abstract void OnTick(ref T agent);

        public virtual void OnExit(ref T agent) {}
        #endregion

        #region Internal
        internal FiniteStateMachineTransition<T>[] Transitions { get; set; }
        #endregion
    }
}