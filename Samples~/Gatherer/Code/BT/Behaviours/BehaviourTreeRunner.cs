using UnityEngine;
using Planilo;
using Planilo.BT;
using Planilo.BT.Builder;

namespace PlaniloSamples.BT
{
    public class BehaviourTreeRunner<T> : MonoBehaviour, IAIBehaviourDebugger<BehaviourTreeGraph, BehaviourTreeState> where T : struct
    {
        #region Protected
        protected T agent;

        protected virtual void UpdateWorldState() {}
        #endregion

        #region Private
        [SerializeField] BehaviourTreeGraph behaviourDefinition = default;
        BehaviourTreeState behaviourTreeState = default;
        IAIBehaviour<T, BehaviourTreeState> behaviourTree = default;

        void Awake()
        {
            behaviourTree = behaviourDefinition.Build<T>();
            agent = default;
            behaviourTreeState = behaviourTree.Initialize(ref agent);
        }

        void Update()
        {
            UpdateWorldState();
            behaviourTree.Run(ref agent, ref behaviourTreeState);
        }
        #endregion

    #if UNITY_EDITOR
        #region Editor
        public BehaviourTreeState GetState()
        {
            return behaviourTreeState;
        }

        public BehaviourTreeGraph GetBehaviour()
        {
            return behaviourDefinition;
        }
        #endregion
    #endif
    }
}
