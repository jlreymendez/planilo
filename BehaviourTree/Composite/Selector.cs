namespace Planilo.BT
{
    public class Selector<T> : CompositeNode<T>
    {
        #region Public
        public Selector(BehaviourTreeNode<T>[] children, int index) : base(children, index) {}

        public override BehaviourTreeResult Update(ref T agent, BehaviourTreeNodeState[] states)
        {
            ref var state = ref states[nodeIndex];
            while (Current(state) != null)
            {
                state.Result = Current(state).Run(ref agent, states);
                if (!state.IsFailure) { break; }
                NextChild(ref state);
            }

            return state.Result;
        }
        #endregion
    }
}
