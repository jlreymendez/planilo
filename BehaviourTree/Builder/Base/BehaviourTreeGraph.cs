using System;
using UnityEngine;
using XNode;

namespace Planilo.BT.Builder
{
    [CreateAssetMenu(menuName = "Planilo/BT/Tree")]
    public class BehaviourTreeGraph : NodeGraph, IAIBehaviourBuilder<BehaviourTreeState>
    {
        #region Public
        public IAIBehaviour<T, BehaviourTreeState> Build<T>()
        {
            var startIndex = -1;
            var rootNode = root.Build<T>(ref startIndex);

            return new BehaviourTree<T>(rootNode, root.Size);
        }

        public void SetRoot(BehaviourTreeGraphNode node)
        {
            if (root) { root.IsRoot = false; }
            root = node;
            root.IsRoot = true;
        }

        public override Node AddNode(Type type)
        {
            // Only allow the right type of nodes.
            if (typeof(BehaviourTreeGraphNode).IsAssignableFrom(type) == false)
            {
                return null;
            }
            // Set first node as root by default
            var node = base.AddNode(type) as BehaviourTreeGraphNode;
            if (root == null)
            {
                SetRoot(node);
            }

            return node;
        }

        public BehaviourTreeGraphNode Root => root;
        #endregion

        #region Protected

        #endregion

        #region Private
        [SerializeField] BehaviourTreeGraphNode root;
        #endregion
    }
}
