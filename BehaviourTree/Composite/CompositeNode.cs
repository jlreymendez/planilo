namespace Planilo.BT
{
    public abstract class CompositeNode<T> : BehaviourTreeNode<T>
    {
        #region Constructor
        public CompositeNode(BehaviourTreeNode<T>[] children, int index) : base(index)
        {
            this.children = children;
        }
        #endregion

        #region Public
        public override void Initialize(ref T agent, ref BehaviourTreeNodeState nodeState)
        {
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
