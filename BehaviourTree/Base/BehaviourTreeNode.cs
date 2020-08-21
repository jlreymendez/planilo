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
        public BehaviourTreeResult Run(ref T agent, BehaviourTreeState[] states)
        {
            ref var state = ref states[nodeIndex];
            state.LastUpdateTime = Time.time;
            if (state.IsRunning == false) { Initialize(ref agent, ref state); }
            state.Result = Update(ref agent, states);
            if (state.IsRunning == false) { Finalize(ref agent, ref state); }
            return state.Result;
        }

        public virtual void Initialize(ref T agent, ref BehaviourTreeState state) {}

        public abstract BehaviourTreeResult Update(ref T agent, BehaviourTreeState[] states);

        public virtual void Finalize(ref T agent, ref BehaviourTreeState state) {}
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
