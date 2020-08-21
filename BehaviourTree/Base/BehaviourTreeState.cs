using System.Collections;
using UnityEngine;

namespace Planilo.BT
{
    public struct BehaviourTreeState
    {
        #region Static
        public static BehaviourTreeState Success
        {
            get => new BehaviourTreeState(BehaviourTreeResult.Success);
        }

        public static BehaviourTreeState Failure
        {
            get => new BehaviourTreeState(BehaviourTreeResult.Failure);
        }

        public static BehaviourTreeState Running
        {
            get => new BehaviourTreeState(BehaviourTreeResult.Running);
        }
        #endregion

        #region Constructor
        public BehaviourTreeState(BehaviourTreeResult result)
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
