namespace Planilo.BT.Builder
{
    [CreateNodeMenu("Planilo/BT/Composite/Sequencer")]
    public class SequencerGraphNode : CompositeGraphNode
    {
        #region Protected
        protected override CompositeNode<T> BuildNode<T>(BehaviourTreeNode<T>[] children, int index,AbortType abortType)
        {
            return new Sequencer<T>(children, index,abortType);
        }
        #endregion
    }
}
