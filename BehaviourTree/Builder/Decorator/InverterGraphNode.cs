namespace Planilo.BT.Builder
{
    [CreateNodeMenu("Planilo/BT/Decorator/Inverter")]
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