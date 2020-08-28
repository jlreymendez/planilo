using System;
using Planilo.BT;
using Planilo.BT.Builder;
using PlaniloSamples.Common;
using UnityEngine;
using XNode;

namespace PlaniloSamples.BT
{
    public class CheckNeedsRestNode : LeafNode<Gatherer>
    {
        public CheckNeedsRestNode(int index) : base(index) {}

        public override BehaviourTreeResult Update(ref Gatherer agent, BehaviourTreeNodeState[] states)
        {
            if (Time.time - agent.LastRest >= agent.WorkTime)
            {
                return BehaviourTreeResult.Success;
            }

            return BehaviourTreeResult.Failure;
        }
    }

    [Node.CreateNodeMenuAttribute("PlaniloSamples/Gatherer/CheckNeedsRest")]
    public class CheckNeedsRestGraphNode : LeafGraphNode
    {
        #region Protected
        protected override Type AllowedType => typeof(Gatherer);

        protected override BehaviourTreeNode<T> ProtectedBuild<T>(ref int index)
        {
            return new CheckNeedsRestNode(index) as BehaviourTreeNode<T>;
        }
        #endregion
    }
}