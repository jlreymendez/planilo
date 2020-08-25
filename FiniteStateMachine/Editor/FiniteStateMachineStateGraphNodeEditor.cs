using Planilo.FSM.Builder;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace Planilo.FSM.Editor
{
    [CustomNodeEditor(typeof(FiniteStateMachineStateGraphNode))]
    public class FiniteStateMachineStateGraphNodeEditor : NodeEditor
    {
        Color rootColor = new Color(0.42f, 0.18f, 0.18f);
        Color inactiveColor = new Color(0.5f, 0.5f, 0.5f);
        Color runningColor = new Color(0.43f, 0.41f, 0.18f);

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

        Color GetEditorTint()
        {
            var node = target as FiniteStateMachineStateGraphNode;
            var hasParent = node.GetInputPort("entry").Connection != null;
            return node.IsEntry ? rootColor : hasParent ? base.GetTint() : base.GetTint() * inactiveColor;
        }
    }
}
