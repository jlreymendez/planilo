namespace Planilo.BT
{
    public class Selector<T> : CompositeNode<T>
    {
        #region Public
        public Selector(BehaviourTreeNode<T>[] children, int index) : base(children, index) {}

        public override BehaviourTreeResult Update(ref T agent, BehaviourTreeState[] states)
        {
            ref var state = ref states[nodeIndex];
            while (current)
            {
                state.Result = current.Run(ref agent, states);
                if (!state.IsFailure) { break; }
                NextChild(ref state);
            }

            return state.Result;
        }
        #endregion
    }
}
