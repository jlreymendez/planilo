namespace Planilo.BT
{
    public class Sequencer<T> : CompositeNode<T>
    {
        #region Public
        public Sequencer(BehaviourTreeNode<T>[] children, int index,AbortType abortType) : base(children, index,abortType) {}

        public override BehaviourTreeResult Update(ref T agent, BehaviourTreeNodeState[] states)
        {
            ref var state = ref states[nodeIndex];

            if (abortType == AbortType.Self)
            {
                state.Enumerator.Reset();
                state.Enumerator.MoveNext();
            }

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
