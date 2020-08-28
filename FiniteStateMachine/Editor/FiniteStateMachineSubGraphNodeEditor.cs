using System.Collections.Generic;
using Planilo.FSM.Builder;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace Planilo.FSM.Editor
{
    [CustomNodeEditor(typeof(FiniteStateMachineSubGraphNode))]
    public class FiniteStateMachineSubGraphNodeEditor : FiniteStateMachineStateGraphNodeEditor
    {
        public override void OnHeaderGUI()
        {
            var stateNode = target as FiniteStateMachineSubGraphNode;
            var name = target.name.Replace("Finite State Machine Sub Graph", "Sub Graph State");
            name = string.Format("{0}{1}{2}", stateNode.IsEntry ? "→ " : "", name, stateNode.IsExit ? " →" : "");
            GUILayout.Label(name, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
        }

        public override Color GetTint()
        {
            // Make sure node is connected.
            if (Selection.activeGameObject == null || Application.isPlaying == false) return GetEditorTint();

            // Check if there is an active game object with a runner.
            var runner = Selection.activeGameObject.GetComponent<IAIBehaviourDebugger<FiniteStateMachineGraph, FiniteStateMachineRuntimeState>>();
            if (runner == null) return GetEditorTint();

            // Check if it is running.
            var behaviourGraph = runner.GetBehaviour();
            var runnerState = runner.GetState();
            if (IsSubGraphRunning(target as FiniteStateMachineSubGraphNode, behaviourGraph, runnerState, new List<int>()))
            {
                return GetRunningColor();
            }

            return GetEditorTint();
        }

        bool IsStateRunning(FiniteStateMachineStateGraphNode stateNode, FiniteStateMachineGraph behaviourGraph, FiniteStateMachineRuntimeState state)
        {
            if (behaviourGraph.TryGetNodeIndex(stateNode.GetInstanceID(), out var nodeIndex))
            {
                if (state.CurrentState == nodeIndex)
                {
                    return true;
                }
            }

            return false;
        }

        bool IsSubGraphRunning(FiniteStateMachineSubGraphNode subGraphNode, FiniteStateMachineGraph behaviourGraph, FiniteStateMachineRuntimeState state, List<int> checkedSubgraphs)
        {
            checkedSubgraphs.Add(subGraphNode.GetInstanceID());
            var subGraph = subGraphNode.SubGraph;
            foreach (var node in subGraph.nodes)
            {
                var running = false;
                // If node is another subgraph execute recursively but prevent infinite cycles.
                if (node is FiniteStateMachineSubGraphNode && checkedSubgraphs.Contains(node.GetInstanceID()) == false)
                {
                    running = IsSubGraphRunning(node as FiniteStateMachineSubGraphNode, behaviourGraph, state, checkedSubgraphs);
                }
                else if (node is FiniteStateMachineStateGraphNode)
                {
                    running = IsStateRunning(node as FiniteStateMachineStateGraphNode, behaviourGraph, state);
                }

                if (running) return true;
            }

            return false;
        }
    }
}
