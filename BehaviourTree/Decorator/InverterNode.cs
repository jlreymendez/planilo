namespace Planilo.BT
{
    public class InverterNode<T> : DecoratorNode<T>
    {
        #region Constructor
        public InverterNode(BehaviourTreeNode<T> child, int index) : base(child, index) { }
        #endregion

        #region Public
        public override BehaviourTreeResult Update(ref T agent, BehaviourTreeState[] states)
        {
            ref var state = ref states[nodeIndex];
            state.Result = UpdateChild(ref agent, states);

            if (state.IsFailure) { state.Result = BehaviourTreeResult.Success; }
            if (state.IsSuccess) { state.Result = BehaviourTreeResult.Failure; }

            return state.Result;
        }
        #endregion
    }
}