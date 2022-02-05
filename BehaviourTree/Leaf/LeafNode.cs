namespace Planilo.BT
{
    public abstract class LeafNode<T> : BehaviourTreeNode<T>
    {
        public LeafNode(int index) : base(index) {}
    }
}
