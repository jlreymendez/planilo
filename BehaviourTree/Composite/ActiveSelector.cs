namespace Planilo.BT
{
    public class ActiveSelector<T> : Selector<T>
    {
        public ActiveSelector(BehaviourTreeNode<T>[] children, int index,AbortType abortType) : base(children, index,abortType) {}

        public override BehaviourTreeResult Update(ref T agent, BehaviourTreeNodeState[] states)
        {
            states[nodeIndex].Enumerator.Reset();
            states[nodeIndex].Enumerator.MoveNext();
            return base.Update(ref agent, states);
        }
    }
}