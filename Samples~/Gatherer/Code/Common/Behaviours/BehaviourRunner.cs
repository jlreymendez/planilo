using UnityEngine;
using Planilo;

namespace PlaniloSamples.Common
{
    public class BehaviourRunner<TBehaviourGraph, TBehaviourState, TAgent> : MonoBehaviour, IAIBehaviourDebugger<TBehaviourGraph, TBehaviourState>
        where TBehaviourGraph : IAIBehaviourBuilder<TBehaviourState>
        where TAgent : struct
    {
        #region Protected
        protected TAgent agent;

        protected virtual void UpdateWorldState() {}
        #endregion

        #region Private
        [SerializeField] TBehaviourGraph behaviourDefinition = default;
        TBehaviourState behaviourTreeState = default;
        IAIBehaviour<TAgent, TBehaviourState> behaviourTree = default;

        void Awake()
        {
            behaviourTree = behaviourDefinition.Build<TAgent>();
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
        public TBehaviourState GetState()
        {
            return behaviourTreeState;
        }

        public TBehaviourGraph GetBehaviour()
        {
            return behaviourDefinition;
        }
        #endregion
    #endif
    }
}