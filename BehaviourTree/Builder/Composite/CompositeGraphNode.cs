using UnityEngine;
using System.Collections.Generic;

namespace Planilo.BT.Builder
{
    [NodeTint("#2e4e6b")]
    public abstract class CompositeGraphNode : BehaviourTreeGraphNode
    {
        #region Public
        public override int Size
        {
            get
            {
                var size = 0;
                for (var i = 0; i < children.Count; i++)
                {
                    var port = GetOutputPort(string.Format(ChildrenPortNameFormat, i));
                    var connectedNode = port.Connection.node as BehaviourTreeGraphNode;
                    if (connectedNode == null) continue;
                    size += connectedNode.Size;
                }

                return size + 1;
            }
        }
        #endregion

        #region Protected
        protected override BehaviourTreeNode<T> ProtectedBuild<T>(ref int index)
        {
            var nodeIndex = index;
            var builtChildren = BuildChildren<T>(ref index);
            return BuildNode(builtChildren, nodeIndex);
        }

        protected BehaviourTreeNode<T>[] BuildChildren<T>(ref int index)
        {
            var childrenNodes = new BehaviourTreeNode<T>[children.Count];

            for (var i = 0; i < children.Count; i++)
            {
                var port = GetOutputPort(string.Format(ChildrenPortNameFormat, i));
                var connectedNode = port.Connection.node as BehaviourTreeGraphNode;
                if (connectedNode != null)
                {
                    childrenNodes[i] = connectedNode.Build<T>(ref index);
                }
            }

            return childrenNodes;
        }

        protected abstract CompositeNode<T> BuildNode<T>(BehaviourTreeNode<T>[] children, int index);
        #endregion

        #region Private
        [SerializeField, Output(dynamicPortList = true)] List<BehaviourTreeGraphConnection> children;

        const string ChildrenPortNameFormat = "children {0}";
        #endregion
    }
}
