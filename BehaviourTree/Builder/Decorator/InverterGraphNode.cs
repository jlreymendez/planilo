namespace Planilo.BT.Builder
{
    [CreateNodeMenu("Planilo/BT/Decorator/Inverter")]
    [NodeTint("#6b2e53")]
    public class InverterGraphNode : DecoratorGraphNode
    {
        #region Protected
        protected override DecoratorNode<T> BuildNode<T>(BehaviourTreeNode<T> child, int index)
        {
            return new InverterNode<T>(child, index);
        }
        #endregion
    }
}