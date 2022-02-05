namespace Planilo.BT.Builder
{
    [CreateNodeMenu("Planilo/BT/Composite/Selector")]
    public class SelectorGraphNode : CompositeGraphNode
    {
        #region Protected
        protected override CompositeNode<T> BuildNode<T>(BehaviourTreeNode<T>[] children, int index)
        {
            return new Selector<T>(children, index);
        }
        #endregion
    }
}
