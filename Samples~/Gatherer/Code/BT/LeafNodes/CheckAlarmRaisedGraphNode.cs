using System;
using Planilo.BT;
using Planilo.BT.Builder;
using PlaniloSamples.Common;
using XNode;

namespace PlaniloSamples.BT
{
    public class CheckAlarmRaisedNode : LeafNode<Gatherer>
    {
        public CheckAlarmRaisedNode(int index) : base(index) {}

        public override BehaviourTreeResult Update(ref Gatherer agent, BehaviourTreeNodeState[] states)
        {
            return agent.World.Alarm ? BehaviourTreeResult.Success : BehaviourTreeResult.Failure;
        }
    }

    [Node.CreateNodeMenuAttribute("PlaniloSamples/Gatherer/CheckAlarmRaised")]
    public class CheckAlarmRaisedGraphNode : LeafGraphNode
    {
        #region Protected
        protected override Type AllowedType => typeof(Gatherer);

        protected override BehaviourTreeNode<T> ProtectedBuild<T>(ref int index)
        {
            return new CheckAlarmRaisedNode(index) as BehaviourTreeNode<T>;
        }
        #endregion
    }
}