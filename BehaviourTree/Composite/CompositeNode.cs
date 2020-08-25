namespace Planilo.BT
{
    public abstract class CompositeNode<T> : BehaviourTreeNode<T>
    {
        #region Constructor
        public CompositeNode(BehaviourTreeNode<T>[] children, int index) : base(index)
        {
            this.children = children;
            enumerator = new BehaviourTreeEnumerator(children.Length);
        }
        #endregion

        #region Public
        public override void Initialize(ref T agent, ref BehaviourTreeNodeState nodeState)
        {
            enumerator.Reset();
            nodeState.Result = BehaviourTreeResult.Success;
            NextChild(ref nodeState);
        }
        #endregion

        #region Protected
        protected BehaviourTreeNode<T> current;

        protected void NextChild(ref BehaviourTreeNodeState nodeState)
        {
            var hasValue = enumerator.MoveNext();
            current = hasValue ? children[enumerator.Current] : null;
            nodeState.Enumerator = enumerator;
        }
        #endregion

        #region Private
        BehaviourTreeNode<T>[] children;
        BehaviourTreeEnumerator enumerator;
        #endregion
    }
}
