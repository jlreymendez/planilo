using System.Collections.Generic;
using UnityEngine;

namespace Planilo.FSM.Builder
{
    [CreateNodeMenu("Planilo/FSM/States/SubGraphState")]
    [NodeWidth(300)]
    public sealed class FiniteStateMachineSubGraphNode : FiniteStateMachineStateGraphNode
    {
        #region Internal
        internal override void Build<T>(ref int nextIndex, List<FiniteStateMachineState<T>> states, Dictionary<int, int> idToIndexMap)
        {
            // Check and register index.
            var instanceId = GetInstanceID();
            if (idToIndexMap.ContainsKey(instanceId)) return;
            idToIndexMap[instanceId] = nextIndex;

            // Create subgraph.
            subGraph.EntryState.Build(ref nextIndex, states, idToIndexMap);

            var exitStates = GetExitStates(states, idToIndexMap, exitType);

            foreach (var exitState in exitStates)
            {
                // Prepend parent graph transitions to node transition.
                var transitions = new List<FiniteStateMachineTransition<T>>(BuildTransitions(ref nextIndex, states, idToIndexMap));
                transitions.AddRange(exitState.Transitions);
                exitState.Transitions = transitions.ToArray();
            }
        }

        internal FiniteStateMachineState<T>[] GetExitStates<T>(List<FiniteStateMachineState<T>> states, Dictionary<int, int> idToIndexMap, FiniteStateMachineGraphExitType withExitType)
        {
            var exitStates = new List<FiniteStateMachineState<T>>();
            foreach (var node in subGraph.nodes)
            {
                var stateNode = node as FiniteStateMachineStateGraphNode;
                if (stateNode == null) continue;

                if (idToIndexMap.ContainsKey(node.GetInstanceID()) == false) continue;
                if (withExitType == FiniteStateMachineGraphExitType.ExitOnly && stateNode.IsExit == false) continue;

                var subGraphNode = stateNode as FiniteStateMachineSubGraphNode;
                if (subGraphNode != null)
                {
                    exitStates.AddRange(subGraphNode.GetExitStates(states, idToIndexMap, withExitType));
                }
                else
                {
                    var stateIndex = idToIndexMap[node.GetInstanceID()];
                    exitStates.Add(states[stateIndex]);
                }
            }

            return exitStates.ToArray();
        }

        public FiniteStateMachineGraph SubGraph => subGraph;
        #endregion

        #region Protected
        protected override FiniteStateMachineState<T> ProtectedBuild<T>() => null;
        #endregion

        #region Private
        [SerializeField] FiniteStateMachineGraph subGraph = default;
        [SerializeField] FiniteStateMachineGraphExitType exitType = default;
        #endregion
    }

    public enum FiniteStateMachineGraphExitType
    {
        All,
        ExitOnly
    }
}