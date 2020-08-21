namespace Planilo.BT
{
    public class BehaviourTree<T> : IAIBehaviour<T>
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

        public BehaviourTreeState[] Run(ref T agent, BehaviourTreeState[] state)
        {
            root.Run(ref agent, state);
            return state;
        }
        #endregion

        #region Private
        BehaviourTreeNode<T> root;
        int size;
        #endregion
    }
}
