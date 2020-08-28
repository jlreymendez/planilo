using System;
using Planilo.BT;
using Planilo.BT.Builder;
using PlaniloSamples.Common;
using UnityEngine;
using XNode;

namespace PlaniloSamples.BT
{
    public class GoHomeNode : MoveToTargetNode
    {
        public GoHomeNode(int index) : base(index) {}

        public override void Initialize(ref Gatherer agent, ref BehaviourTreeNodeState nodeState)
        {
            agent.Target = agent.World.Home;
        }
    }

    [Node.CreateNodeMenuAttribute("PlaniloSamples/Gatherer/GoHome")]
    public class GoHomeGraphNode : LeafGraphNode
    {
        #region Protected
        protected override Type AllowedType => typeof(Gatherer);

        protected override BehaviourTreeNode<T> ProtectedBuild<T>(ref int index)
        {
            return new GoHomeNode(index) as BehaviourTreeNode<T>;
        }
        #endregion
    }
}