using System;
using Planilo.BT;
using Planilo.BT.Builder;
using PlaniloSamples.Common;

namespace PlaniloSamples.BT
{
    public class DropResourceNode : LeafNode<Gatherer>
    {
        public DropResourceNode(int index) : base(index) { }

        public override BehaviourTreeResult Update(ref Gatherer agent, BehaviourTreeNodeState[] states)
        {
            if (agent.Resource != null && agent.Resource.CarrierId == agent.Id)
            {
                agent.Resource.Drop(agent.Transform.position);
                agent.Resource.CarrierId = 0;
                agent.Resource = null;
            }

            return BehaviourTreeResult.Success;
        }
    }

    public class DropResourceGraphNode : LeafGraphNode
    {
        #region Protected
        protected override Type AllowedType => typeof(Gatherer);

        protected override BehaviourTreeNode<T> ProtectedBuild<T>(ref int index)
        {
            return new DropResourceNode(index) as BehaviourTreeNode<T>;
        }
        #endregion
    }
}