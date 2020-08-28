using System;
using Planilo.BT;
using Planilo.BT.Builder;
using PlaniloSamples.Common;
using UnityEngine;
using XNode;

namespace PlaniloSamples.BT
{
    public class ConsumeResourceNode : LeafNode<Gatherer>
    {
        public ConsumeResourceNode(int index) : base(index) {}

        public override BehaviourTreeResult Update(ref Gatherer agent, BehaviourTreeNodeState[] states)
        {
            if (agent.Resource == null) return BehaviourTreeResult.Failure;

            var distance = Vector3.Distance(agent.Transform.position, agent.World.Home);
            if (distance > agent.Reach) return BehaviourTreeResult.Failure;

            agent.Resource.Consume();
            agent.Resource = null;
            return BehaviourTreeResult.Success;
        }
    }

    [Node.CreateNodeMenuAttribute("PlaniloSamples/Gatherer/ConsumeResource")]
    public class ConsumeResourceGraphNode : LeafGraphNode
    {
        #region Protected
        protected override Type AllowedType => typeof(Gatherer);

        protected override BehaviourTreeNode<T> ProtectedBuild<T>(ref int index)
        {
            return new ConsumeResourceNode(index) as BehaviourTreeNode<T>;
        }
        #endregion
    }
}