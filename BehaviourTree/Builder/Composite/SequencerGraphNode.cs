namespace Planilo.BT.Builder
{
    [CreateNodeMenu("Planilo/BT/Composite/Sequencer")]
    [NodeTint("#2e4e6b")]
    public class SequencerGraphNode : CompositeGraphNode
    {
        #region Protected
        protected override CompositeNode<T> BuildNode<T>(BehaviourTreeNode<T>[] children, int index)
        {
            return new Sequencer<T>(children, index);
        }

        protected override void Init()
        {
            name = "Sequencer";
        }
        #endregion
    }
}
