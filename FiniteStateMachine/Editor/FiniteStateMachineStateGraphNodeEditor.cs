using Planilo.FSM.Builder;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace Planilo.FSM.Editor
{
    [CustomNodeEditor(typeof(FiniteStateMachineStateGraphNode))]
    public class FiniteStateMachineStateGraphNodeEditor : NodeEditor
    {
        Color entryColor = new Color(0.18f, 0.42f, 0.22f);
        Color entryExitColor = new Color(0.3f, 0.3f, 0.22f);
        Color exitColor = new Color(0.42f, 0.18f, 0.22f);
        Color inactiveColor = new Color(0.5f, 0.5f, 0.5f);
        Color runningColor = new Color(0.43f, 0.41f, 0.18f);

        public override void OnHeaderGUI()
        {
            var stateNode = target as FiniteStateMachineStateGraphNode;
            var name = stateNode.name.Replace(" State Graph", "");
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
            var node = target as FiniteStateMachineStateGraphNode;
            if (behaviourGraph.TryGetNodeIndex(node.GetInstanceID(), out var nodeIndex))
            {
                if (runnerState.CurrentState == nodeIndex)
                {
                    return runningColor;
                }
            }

            return GetEditorTint();
        }

        protected Color GetRunningColor()
        {
            return runningColor;
        }

        protected Color GetEditorTint()
        {
            var node = target as FiniteStateMachineStateGraphNode;
            var isDisconnected = node.GetInputPort("entry").Connection == null;

            if (node.IsEntry && node.IsExit)
            {
                return entryExitColor;
            }
            if (node.IsEntry)
            {
                return entryColor;
            }
            if (node.IsExit)
            {
                return exitColor;
            }
            if (isDisconnected)
            {
                return base.GetTint() * inactiveColor;
            }

            return base.GetTint();
        }
    }
}
