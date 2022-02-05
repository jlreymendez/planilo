using System;
using Planilo.BT;
using Planilo.BT.Builder;
using PlaniloSamples.Common;
using UnityEngine;
using XNode;

namespace PlaniloSamples.BT
{
    public class MoveToTargetNode : LeafNode<Gatherer>
    {
        public MoveToTargetNode(int index) : base(index) {}

        public override BehaviourTreeResult Update(ref Gatherer agent, BehaviourTreeNodeState[] states)
        {
            var position = agent.Transform.position;
            var distance = Vector3.Distance(position, agent.Target);
            if (distance <= agent.Reach)
            {
                return BehaviourTreeResult.Success;
            }

            var direction = Vector3.Normalize(agent.Target - position);
            agent.Transform.position += direction * (Time.deltaTime * agent.Speed);
            return BehaviourTreeResult.Running;
        }
    }

    [Node.CreateNodeMenuAttribute("PlaniloSamples/Gatherer/MoveToTarget")]
    public class MoveToTargetGraphNode : LeafGraphNode
    {
        #region Protected
        protected override Type AllowedType => typeof(Gatherer);

        protected override BehaviourTreeNode<T> ProtectedBuild<T>(ref int index)
        {
            return new MoveToTargetNode(index) as BehaviourTreeNode<T>;
        }
        #endregion
    }
}