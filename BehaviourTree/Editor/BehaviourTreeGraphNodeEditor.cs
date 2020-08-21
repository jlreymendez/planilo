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
            var node = target as BehaviourTreeGraphNode;
            if (node.Index < 0) return GetEditorTint();

            // Check if there is an active game object with a runner.
            IAIBehaviourRunner<BehaviourTreeState> runner = Selection.activeGameObject != null ?
                Selection.activeGameObject.GetComponent<IAIBehaviourRunner<BehaviourTreeState>>() : null;
            if (runner == null) return GetEditorTint();

            // Check if it is running.
            var runnerState = runner.GetState();
            var state = runnerState[node.Index];

            return state.LastUpdateTime == Time.time ? runningColor : GetEditorTint();
        }

        Color GetEditorTint()
        {
            var node = target as BehaviourTreeGraphNode;
            var hasParent = node.GetInputPort("parent").Connection != null;
            return node.IsRoot ? rootColor : hasParent ? base.GetTint() : base.GetTint() * inactiveColor;
        }
    }
}