namespace Planilo.BT.Builder
{
    [CreateNodeMenu("Planilo/BT/Composite/ActiveSelector")]
    public class ActiveSelectorGraphNode : CompositeGraphNode
    {
        #region Protected
        protected override CompositeNode<T> BuildNode<T>(BehaviourTreeNode<T>[] children, int index)
        {
            return new ActiveSelector<T>(children, index);
        }
        #endregion
    }
}
