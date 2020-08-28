using System;
using Planilo.BT;
using Planilo.BT.Builder;
using PlaniloSamples.Common;
using UnityEngine;
using XNode;

namespace PlaniloSamples.BT
{
    public class FindResourceNode : LeafNode<Gatherer>
    {
        public FindResourceNode(int index) : base(index) {}

        public override BehaviourTreeResult Update(ref Gatherer agent, BehaviourTreeNodeState[] states)
        {
            agent.Resource = null;

            var minDistance = float.MaxValue;
            foreach (var resource in agent.World.Resources)
            {
                var distance = Vector3.Distance(agent.Transform.position, resource.transform.position);
                if (resource.CarrierId == 0 && distance < minDistance)
                {
                    minDistance = distance;
                    agent.Resource = resource;
                    agent.Target = resource.transform.position;
                }
            }

            if (agent.Resource != null)
            {
                agent.Resource.CarrierId = agent.Id;
                return BehaviourTreeResult.Success;
            }

            return BehaviourTreeResult.Failure;
        }
    }

    [Node.CreateNodeMenuAttribute("PlaniloSamples/Gatherer/FindResource")]
    public class FindResourceGraphNode : LeafGraphNode
    {
        #region Protected
        protected override Type AllowedType => typeof(Gatherer);

        protected override BehaviourTreeNode<T> ProtectedBuild<T>(ref int index)
        {
            return new FindResourceNode(index) as BehaviourTreeNode<T>;
        }
        #endregion
    }
}