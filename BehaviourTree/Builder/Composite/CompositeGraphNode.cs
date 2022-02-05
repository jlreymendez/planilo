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
                for (var i = 0; i < childrenCount; i++)
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

        protected override void Init()
        {
            base.Init();
            // Calculate children count.
            // note: it appears that xNode doesn't populate the children list on init.
                // Which results in children.Count being 0.
            childrenCount = 0;
            while (true)
            {
                var port = GetOutputPort(string.Format(ChildrenPortNameFormat, childrenCount));
                if (port == null) break;
                childrenCount++;
            }
        }

        protected override BehaviourTreeNode<T> ProtectedBuild<T>(ref int index)
        {
            var nodeIndex = index;
            var builtChildren = BuildChildren<T>(ref index);
            return BuildNode(builtChildren, nodeIndex);
        }

        protected BehaviourTreeNode<T>[] BuildChildren<T>(ref int index)
        {
            var childrenNodes = new BehaviourTreeNode<T>[childrenCount];
            for (var i = 0; i < childrenCount; i++)
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
        int childrenCount;

        const string ChildrenPortNameFormat = "children {0}";
        #endregion
    }
}
