namespace Planilo.BT
{
    public class Sequencer<T> : CompositeNode<T>
    {
        #region Public
        public Sequencer(BehaviourTreeNode<T>[] children, int index) : base(children, index) {}

        public override BehaviourTreeResult Update(ref T agent, BehaviourTreeNodeState[] states)
        {
            ref var state = ref states[nodeIndex];
            while (Current(state) != null)
            {
                state.Result = Current(state).Run(ref agent, states);
                if (!state.IsSuccess) { break; }
                NextChild(ref state);
            }

            return state.Result;
        }
        #endregion
    }
}
