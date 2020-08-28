using System;
using Planilo.BT;
using Planilo.BT.Builder;
using PlaniloSamples.Common;
using UnityEngine;
using XNode;

namespace PlaniloSamples.BT
{
    public class RestNode : LeafNode<Gatherer>
    {
        public RestNode(int index) : base(index) {}

        public override void Initialize(ref Gatherer agent, ref BehaviourTreeNodeState state)
        {
            base.Initialize(ref agent, ref state);
            agent.LastRest = Time.time;
        }

        public override BehaviourTreeResult Update(ref Gatherer agent, BehaviourTreeNodeState[] states)
        {
            return Time.time - agent.LastRest > agent.RestTime ? BehaviourTreeResult.Success : BehaviourTreeResult.Running;
        }

        public override void Finalize(ref Gatherer agent, ref BehaviourTreeNodeState state)
        {
            agent.LastRest = Time.time;
        }
    }

    [Node.CreateNodeMenuAttribute("PlaniloSamples/Gatherer/Rest")]
    public class RestGraphNode : LeafGraphNode
    {
        #region Protected
        protected override Type AllowedType => typeof(Gatherer);

        protected override BehaviourTreeNode<T> ProtectedBuild<T>(ref int index)
        {
            return new RestNode(index) as BehaviourTreeNode<T>;
        }
        #endregion
    }
}