namespace Planilo.BT.Builder
{
    [CreateNodeMenu("Planilo/BT/Composite/Selector")]
    public class SelectorGraphNode : CompositeGraphNode
    {
        #region Protected
        protected override CompositeNode<T> BuildNode<T>(BehaviourTreeNode<T>[] children, int index,AbortType abortType)
        {
            return new Selector<T>(children, index,abortType);
        }
        #endregion
    }
}
