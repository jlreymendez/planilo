using System.Collections;
using UnityEngine;

namespace Planilo.BT
{
    public struct BehaviourTreeNodeState
    {
        #region Static
        public static BehaviourTreeNodeState Success
        {
            get => new BehaviourTreeNodeState(BehaviourTreeResult.Success);
        }

        public static BehaviourTreeNodeState Failure
        {
            get => new BehaviourTreeNodeState(BehaviourTreeResult.Failure);
        }

        public static BehaviourTreeNodeState Running
        {
            get => new BehaviourTreeNodeState(BehaviourTreeResult.Running);
        }
        #endregion

        #region Constructor
        public BehaviourTreeNodeState(BehaviourTreeResult result)
        {
            Result = result;
            LastUpdateTime = Time.time;
            Enumerator = default;
        }
        #endregion

        #region Public
        public bool IsSuccess { get => Result == BehaviourTreeResult.Success; }
        public bool IsFailure { get => Result == BehaviourTreeResult.Failure; }
        public bool IsRunning { get => Result == BehaviourTreeResult.Running; }

        public BehaviourTreeResult Result;
        public BehaviourTreeEnumerator Enumerator;
        public float LastUpdateTime;
        #endregion
    }

    public enum BehaviourTreeResult
    {
        Success,
        Failure,
        Running
    }
}
