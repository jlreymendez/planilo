namespace Planilo.BT
{
    public class BehaviourTree<T> : IAIBehaviour<T, BehaviourTreeState>
    {
        #region Public
        public BehaviourTree(BehaviourTreeNode<T> root, int size)
        {
            this.root = root;
            this.size = size;
        }

        public BehaviourTreeState[] Initialize(ref T agent)
        {
            return new BehaviourTreeState[size];
        }

        public void Run(ref T agent, BehaviourTreeState[] state)
        {
            root.Run(ref agent, state);
        }
        #endregion

        #region Private
        BehaviourTreeNode<T> root;
        int size;
        #endregion
    }
}
