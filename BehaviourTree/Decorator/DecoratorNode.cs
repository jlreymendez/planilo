namespace Planilo.BT
{
    public abstract class DecoratorNode<T> : BehaviourTreeNode<T>
    {
        #region Constructor
        public DecoratorNode(BehaviourTreeNode<T> child, int index) : base(index)
        {
            this.child = child;
        }
        #endregion

        #region Protected
        protected BehaviourTreeResult UpdateChild(ref T agent, BehaviourTreeState[] states)
        {
            return child.Update(ref agent, states);
        }
        #endregion

        #region Private
        BehaviourTreeNode<T> child;
        #endregion
    }
}