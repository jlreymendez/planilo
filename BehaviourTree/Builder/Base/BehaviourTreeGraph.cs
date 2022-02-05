using System;
using System.Collections.Generic;
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
        #if UNITY_EDITOR
            root.BuildingGraph = this;
        #endif
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

        #region Private
        [SerializeField] BehaviourTreeGraphNode root;
        #endregion

    #if UNITY_EDITOR
        #region Editor
        Dictionary<int, int> nodeIdToIndexMap = new Dictionary<int, int>();

        public void SetNodeIndex(int nodeId, int index)
        {
            nodeIdToIndexMap[nodeId] = index;
        }

        public bool TryGetNodeIndex(int nodeId, out int index)
        {
            return nodeIdToIndexMap.TryGetValue(nodeId, out index);
        }
        #endregion
    #endif
    }
}
