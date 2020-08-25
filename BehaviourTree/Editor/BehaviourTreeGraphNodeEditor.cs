using Planilo.BT.Builder;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace Planilo.BT.Editor
{
    [CustomNodeEditor(typeof(BehaviourTreeGraphNode))]
    public class BehaviourTreeGraphNodeEditor : NodeEditor
    {
        Color rootColor = new Color(0.42f, 0.18f, 0.18f);
        Color inactiveColor = new Color(0.5f, 0.5f, 0.5f);
        Color runningColor = new Color(0.43f, 0.41f, 0.18f);

        public override Color GetTint()
        {
            // Make sure node is connected.
            if (Selection.activeGameObject == null || Application.isPlaying == false) return GetEditorTint();

            // Check if there is an active game object with a runner.
            var runner = Selection.activeGameObject.GetComponent<IAIBehaviourDebugger<BehaviourTreeGraph, BehaviourTreeState>>();
            if (runner == null) return GetEditorTint();

            // Check if it is running.
            var behaviourGraph = runner.GetBehaviour();
            var runnerState = runner.GetState();
            var node = target as BehaviourTreeGraphNode;
            if (behaviourGraph.TryGetNodeIndex(node.GetInstanceID(), out var nodeIndex))
            {
                var state = runnerState.NodeStates[nodeIndex];
                if (state.LastUpdateTime == Time.time)
                {
                    return runningColor;
                }
            }

            return GetEditorTint();
        }

        Color GetEditorTint()
        {
            var node = target as BehaviourTreeGraphNode;
            var hasParent = node.GetInputPort("parent").Connection != null;
            return node.IsRoot ? rootColor : hasParent ? base.GetTint() : base.GetTint() * inactiveColor;
        }
    }
}