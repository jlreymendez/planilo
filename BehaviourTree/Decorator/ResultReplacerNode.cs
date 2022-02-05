namespace Planilo.BT
{
    public class ResultReplacerNode<T> : DecoratorNode<T>
    {
        readonly BehaviourTreeResult fromSuccess;
        readonly BehaviourTreeResult fromFailure;
        readonly BehaviourTreeResult fromRunning;

        public ResultReplacerNode(BehaviourTreeNode<T> child, int index, BehaviourTreeResult fromSuccess, BehaviourTreeResult fromFailure, BehaviourTreeResult fromRunning) : base(child, index)
        {
            this.fromSuccess = fromSuccess;
            this.fromFailure = fromFailure;
            this.fromRunning = fromRunning;
        }

        public override BehaviourTreeResult Update(ref T agent, BehaviourTreeNodeState[] states)
        {
            ref var state = ref states[nodeIndex];
            state.Result = UpdateChild(ref agent, states);

            if (state.IsSuccess)
            {
                state.Result = fromSuccess;
            }
            else if (state.IsFailure)
            {
                state.Result = fromFailure;
            }
            else if (state.IsRunning)
            {
                state.Result = fromRunning;
            }

            return state.Result;
        }
    }
}