namespace Planilo.BT
{
    public abstract class CompositeNode<T> : BehaviourTreeNode<T>
    {
        public AbortType abortType;
        #region Constructor
        public CompositeNode(BehaviourTreeNode<T>[] children, int index,AbortType abortType) : base(index)
        {
            this.children = children;
            this.abortType = abortType;
        }
        #endregion

        #region Public
        public override void Initialize(ref T agent, BehaviourTreeNodeState[] states)
        {
            ref var nodeState = ref states[nodeIndex];
            nodeState.Enumerator = new BehaviourTreeEnumerator(children.Length);
            nodeState.Result = BehaviourTreeResult.Success;
            NextChild(ref nodeState);
        }
        #endregion

        #region Protected
        protected BehaviourTreeNode<T> Current(BehaviourTreeNodeState nodeState)
        {
            return nodeState.Enumerator.Current < children.Length ? children[nodeState.Enumerator.Current] : null;
        }

        protected void NextChild(ref BehaviourTreeNodeState nodeState)
        {
            nodeState.Enumerator.MoveNext();
        }
        #endregion

        #region Private
        BehaviourTreeNode<T>[] children;
        #endregion
    }
}
