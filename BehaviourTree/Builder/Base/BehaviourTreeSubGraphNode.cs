using UnityEngine;

namespace Planilo.BT.Builder
{
    [CreateNodeMenu("Planilo/BT/Subtree")]
    [NodeTint("#2e6b57")]
    public class BehaviourTreeSubGraphNode : BehaviourTreeGraphNode
    {
        #region Protected
        protected override BehaviourTreeNode<T> ProtectedBuild<T>(ref int index)
        {
            return subGraph.Root.Build<T>(ref index);
        }
        #endregion

        #region Private
        [SerializeField] BehaviourTreeGraph subGraph;
        #endregion
    }
}