namespace Planilo.BT
{
    public class Sequencer<T> : CompositeNode<T>
    {
        #region Public
        public Sequencer(BehaviourTreeNode<T>[] children, int index) : base(children, index) {}

        public override BehaviourTreeResult Update(ref T agent, BehaviourTreeState[] states)
        {
            ref var state = ref states[nodeIndex];
            while (current)
            {
                state.Result = current.Run(ref agent, states);
                if (!state.IsSuccess) { break; }
                NextChild(ref state);
            }

            return state.Result;
        }
        #endregion
    }
}
