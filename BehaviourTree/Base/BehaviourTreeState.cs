namespace Planilo.BT
{
    public struct BehaviourTreeState
    {
        public BehaviourTreeNodeState[] NodeStates;

        public BehaviourTreeState(int size)
        {
            NodeStates = new BehaviourTreeNodeState[size];
        }
    }
}