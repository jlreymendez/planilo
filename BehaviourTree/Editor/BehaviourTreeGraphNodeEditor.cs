using Planilo.BT.Builder;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace Planilo.BT.Editor
{
    [CustomNodeEditor(typeof(BehaviourTreeGraphNode))]
    public class BehaviourTreeGraphNodeEditor : NodeEditor
    {
        Color runningColor = new Color(0.43f, 0.41f, 0.18f);

        public override Color GetTint()
        {
            // Make sure node is connected.
            var node = target as BehaviourTreeGraphNode;
            if (node.Index < 0) return base.GetTint();

            // Check if there is an active game object with a runner.
            IAIBehaviourRunner<BehaviourTreeState> runner = Selection.activeGameObject != null ?
                Selection.activeGameObject.GetComponent<IAIBehaviourRunner<BehaviourTreeState>>() : null;
            if (runner == null) return base.GetTint();

            // Check if it is running.
            var runnerState = runner.GetState();
            var state = runnerState[node.Index];

            return state.LastUpdateTime == Time.time ? runningColor : base.GetTint();
        }
    }
}