using System;
using Planilo.BT;
using Planilo.BT.Builder;
using PlaniloSamples.Common;
using UnityEngine;
using XNode;

namespace PlaniloSamples.BT
{
    public class PickResourceNode : LeafNode<Gatherer>
    {
        public PickResourceNode(int index) : base(index) {}

        public override BehaviourTreeResult Update(ref Gatherer agent, BehaviourTreeNodeState[] states)
        {
            if (!agent.Resource) return BehaviourTreeResult.Failure;

            var distance = Vector3.Distance(agent.Transform.position, agent.Resource.transform.position);
            if (distance > agent.Reach || agent.Resource.Pick() == false) return BehaviourTreeResult.Failure;

            return BehaviourTreeResult.Success;
        }
    }

    [Node.CreateNodeMenuAttribute("PlaniloSamples/Gatherer/PickResource")]
    public class PickResourceGraphNode : LeafGraphNode
    {
        #region Protected
        protected override Type AllowedType => typeof(Gatherer);

        protected override BehaviourTreeNode<T> ProtectedBuild<T>(ref int index)
        {
            return new PickResourceNode(index) as BehaviourTreeNode<T>;
        }
        #endregion
    }
}