using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Planilo.FSM.Builder
{
    [NodeTint("#2e6b38")]
    public abstract class FiniteStateMachineStateGraphNode : FiniteStateMachineGraphNode
    {
        #region Internal
        internal bool IsEntry
        {
            get => isEntry;
            set => isEntry = value;
        }

        internal bool IsExit => isExit;

        [ContextMenu("Set as entry state")]
        internal void SetAsEntry()
        {
            var fsmGraph = graph as FiniteStateMachineGraph;
            fsmGraph.SetEntryNode(this);
        }

        [ContextMenu("Toggle exit state")]
        internal void SetAsExit()
        {
            isExit = !isExit;
        }

        internal virtual void Build<T>(ref int nextIndex, List<FiniteStateMachineState<T>> states, Dictionary<int, int> idToIndexMap)
        {
            // Register index.
            var instanceId = GetInstanceID();
            if (idToIndexMap.ContainsKey(instanceId)) return;

            idToIndexMap[instanceId] = nextIndex;
            nextIndex++;

            var state = ProtectedBuild<T>();
            states.Add(state);
            state.Transitions = BuildTransitions(ref nextIndex, states, idToIndexMap);
        }
        #endregion

        #region Protected
        protected override void Init()
        {
            base.Init();
            // Calculate children count.
            // note: it appears that xNode doesn't populate the children list on init.
            // Which results in children.Count being 0.
            transitionsCount = 0;
            while (true)
            {
                var transition = GetTransitionNode(transitionsCount);
                if (transition == null) break;
                transitionsCount++;
            }
        }

        protected virtual FiniteStateMachineTransition<T>[] BuildTransitions<T>(ref int nextIndex, List<FiniteStateMachineState<T>> states, Dictionary<int, int> idToIndexMap)
        {
            // Build transitions.
            var transitionList =  new List<FiniteStateMachineTransition<T>>();
            for (var i = 0; i < transitionsCount; i++)
            {
                var transition = GetTransitionNode(i);
                var targetState = transition.GetTransitionState();
                if (targetState == null) continue;

                if (idToIndexMap.TryGetValue(targetState.GetInstanceID(), out var targetIndex) == false)
                {
                    targetIndex = nextIndex;
                    targetState.Build(ref nextIndex, states, idToIndexMap);
                }

                transitionList.Add(transition.Build<T>(targetIndex));
            }

            return transitionList.ToArray();
        }

        protected FiniteStateMachineTransitionGraphNode GetTransitionNode(int index)
        {
            var port = GetOutputPort(string.Format(TransitionKeyFormat, index));
            return (FiniteStateMachineTransitionGraphNode) port?.Connection?.node;
        }

        protected abstract FiniteStateMachineState<T> ProtectedBuild<T>();
        #endregion

        #region Private
        [SerializeField, Input] FiniteStateMachineConnectionToState entry;
        [SerializeField, Output(dynamicPortList = true)] List<FiniteStateMachineConnectionToTransition> transitions;
        [HideInInspector, SerializeField] bool isEntry;
        [HideInInspector, SerializeField] bool isExit;
        int transitionsCount;

        const string TransitionKeyFormat = "transitions {0}";
        #endregion
    }
}