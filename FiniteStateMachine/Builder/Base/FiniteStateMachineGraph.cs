using System;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Planilo.FSM.Builder
{
    [CreateAssetMenu(menuName = "Planilo/FSM")]
    public class FiniteStateMachineGraph : NodeGraph, IAIBehaviourBuilder<FiniteStateMachineRuntimeState>
    {
        #region Public
        public IAIBehaviour<TAgent, FiniteStateMachineRuntimeState> Build<TAgent>()
        {
            var nextIndex = 0;
            var states = new List<FiniteStateMachineState<TAgent>>();
            var nodeIdToStateIndexMap = new Dictionary<int, int>();
            entryState.Build(ref nextIndex, states, nodeIdToStateIndexMap);

        #if UNITY_EDITOR
            nodeIdToIndexMap = nodeIdToStateIndexMap;
        #endif

            return new FiniteStateMachine<TAgent>(states.ToArray());
        }

        public override Node AddNode(Type type)
        {
            // Only allow the right type of nodes.
            if (typeof(FiniteStateMachineStateGraphNode).IsAssignableFrom(type) == false &&
                typeof(FiniteStateMachineTransitionGraphNode).IsAssignableFrom(type) == false)
            {
                return null;
            }
            // Set first node as root by default
            var node = base.AddNode(type);
            var stateNode = node as FiniteStateMachineStateGraphNode;
            if (stateNode != null && entryState == null)
            {
                SetEntryNode(stateNode);
            }

            return node;
        }
        #endregion

        #region Internal
        internal FiniteStateMachineStateGraphNode EntryState => entryState;

        internal void SetEntryNode(FiniteStateMachineStateGraphNode node)
        {
            if (entryState != null)
            {
                entryState.IsEntry = false;
            }
            entryState = node;
            entryState.IsEntry = true;
        }
        #endregion

        #region Private
        [SerializeField] FiniteStateMachineStateGraphNode entryState;
        #endregion

    #if UNITY_EDITOR
        #region Editor

        Dictionary<int, int> nodeIdToIndexMap = new Dictionary<int, int>();

        internal bool TryGetNodeIndex(int nodeId, out int index)
        {
            return nodeIdToIndexMap.TryGetValue(nodeId, out index);
        }
        #endregion
    #endif
    }
}