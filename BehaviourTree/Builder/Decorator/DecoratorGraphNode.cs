using UnityEngine;

namespace Planilo.BT.Builder
{
    public abstract class DecoratorGraphNode : BehaviourTreeGraphNode
    {
        #region Public
        public override int Size
        {
            get
            {
                var port = GetOutputPort(string.Format(ChildPortNameFormat));
                var connectedNode = port.Connection.node as BehaviourTreeGraphNode;
                return connectedNode == null ? 1 : connectedNode.Size + 1;
            }
        }
        #endregion

        #region Protected
        protected override BehaviourTreeNode<T> ProtectedBuild<T>(ref int index)
        {
            var nodeIndex = index;
            var builtChild = BuildChild<T>(ref index);
            return BuildNode<T>(builtChild, nodeIndex);
        }

        protected BehaviourTreeNode<T> BuildChild<T>(ref int index)
        {
            var port = GetOutputPort(string.Format(ChildPortNameFormat));
            var connectedNode = port.Connection.node as BehaviourTreeGraphNode;

            return connectedNode != null ? connectedNode.Build<T>(ref index) : null;
        }

        protected abstract DecoratorNode<T> BuildNode<T>(BehaviourTreeNode<T> child, int nodeIndex);
        #endregion

        #region Private
        [SerializeField, Output(dynamicPortList = false)] BehaviourTreeGraphConnection child;
        const string ChildPortNameFormat = "child";
        #endregion
    }
}