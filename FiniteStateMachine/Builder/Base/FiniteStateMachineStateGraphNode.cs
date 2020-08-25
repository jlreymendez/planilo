using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Planilo.FSM.Builder
{
    [NodeTint("#2e6b38")]
    public abstract class FiniteStateMachineStateGraphNode : FiniteStateMachineGraphNode
    {
        #region Internal
        internal bool IsEntry { get; set; }

        [ContextMenu("Set as entry state")]
        internal void SetAsRoot()
        {
            var fsmGraph = graph as FiniteStateMachineGraph;
            fsmGraph.SetEntryNode(this);
        }

        internal void Build<T>(ref int nextIndex, List<FiniteStateMachineState<T>> states, Dictionary<int, int> idToIndexMap)
        {
            // Register index.
            var instanceId = GetInstanceID();
            if (idToIndexMap.ContainsKey(instanceId)) return;

            var index = nextIndex;
            idToIndexMap[instanceId] = index;
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
                var transition = GetTransition(transitionsCount);
                if (transition == null) break;
                transitionsCount++;
            }
        }

        protected abstract FiniteStateMachineState<T> ProtectedBuild<T>();
        #endregion

        #region Private
        [SerializeField, Input] FiniteStateMachineConnectionToState entry;
        [SerializeField, Output(dynamicPortList = true)] List<FiniteStateMachineConnectionToTransition> transitions;
        int transitionsCount;

        FiniteStateMachineTransition<T>[] BuildTransitions<T>(ref int nextIndex, List<FiniteStateMachineState<T>> states, Dictionary<int, int> idToIndexMap)
        {
            // Build transitions.
            var transitionList =  new List<FiniteStateMachineTransition<T>>();
            for (var i = 0; i < transitionsCount; i++)
            {
                var transition = GetTransition(i);
                var targetState = transition.GetTransitionState();
                if (targetState == null) continue;

                if (idToIndexMap.TryGetValue(targetState.GetInstanceID(), out var targetIndex) == false)
                {
                    targetIndex = ++nextIndex;
                    targetState.Build(ref nextIndex, states, idToIndexMap);
                }

                transitionList.Add(transition.Build<T>(targetIndex));
            }

            return transitionList.ToArray();
        }

        FiniteStateMachineTransitionGraphNode GetTransition(int index)
        {
            var port = GetOutputPort(string.Format(TransitionKeyFormat, index));
            return (FiniteStateMachineTransitionGraphNode) port?.Connection?.node;
        }

        const string TransitionKeyFormat = "transitions {0}";
        #endregion
    }
}