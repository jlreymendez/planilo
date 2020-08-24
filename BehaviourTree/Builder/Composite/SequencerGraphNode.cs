namespace Planilo.BT.Builder
{
    [CreateNodeMenu("Planilo/BT/Composite/Sequencer")]
    public class SequencerGraphNode : CompositeGraphNode
    {
        #region Protected
        protected override CompositeNode<T> BuildNode<T>(BehaviourTreeNode<T>[] children, int index)
        {
            return new Sequencer<T>(children, index);
        }

        protected override void Init()
        {
            base.Init();
            name = "Sequencer";
        }
        #endregion
    }
}
