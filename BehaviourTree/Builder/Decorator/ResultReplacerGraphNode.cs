namespace Planilo.BT.Builder
{
    [CreateNodeMenu("Planilo/BT/Decorator/ResultReplacer")]
    public class ResultReplacerGraphNode : DecoratorGraphNode
    {
        #region Public

        public BehaviourTreeResult FromSuccess = BehaviourTreeResult.Success;
        public BehaviourTreeResult FromFailure = BehaviourTreeResult.Failure;
        public BehaviourTreeResult FromRunning = BehaviourTreeResult.Running;
        #endregion

        #region Protected
        protected override DecoratorNode<T> BuildNode<T>(BehaviourTreeNode<T> child, int index)
        {
            return new ResultReplacerNode<T>(child, index, FromSuccess, FromFailure, FromRunning);
        }
        #endregion
    }
}