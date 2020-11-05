using UnityEngine;

namespace Planilo.BT
{
    public abstract class BehaviourTreeNode<T>
    {
        #region Constructor
        public BehaviourTreeNode(int nodeIndex)
        {
            this.nodeIndex = nodeIndex;
        }
        #endregion

        #region Public
        public BehaviourTreeResult Run(ref T agent, BehaviourTreeNodeState[] states)
        {
            ref var state = ref states[nodeIndex];
            state.LastUpdateTime = Time.time;
            if (state.IsRunning == false) { Initialize(ref agent, states); }
            state.Result = Update(ref agent, states);
            if (state.IsRunning == false) { Finalize(ref agent, states); }
            return state.Result;
        }

        public virtual void Initialize(ref T agent, BehaviourTreeNodeState[] states) {}

        public abstract BehaviourTreeResult Update(ref T agent, BehaviourTreeNodeState[] states);

        public virtual void Finalize(ref T agent, BehaviourTreeNodeState[] states) {}
        #endregion

        #region Protected
        protected int nodeIndex;
        #endregion

        #region Operators
        public static implicit operator bool(BehaviourTreeNode<T> node)
        {
            return node != null;
        }
        #endregion
    }
}
