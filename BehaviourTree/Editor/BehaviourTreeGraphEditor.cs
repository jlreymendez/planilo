using System;
using Planilo.BT.Builder;
using UnityEditor;
using XNodeEditor;

namespace Planilo.BT.Editor
{
    [CustomNodeGraphEditor(typeof(BehaviourTreeGraph))]
    public class BehaviourTreeGraphEditor : NodeGraphEditor
    {
        public override string GetNodeMenuName(Type type)
        {
            if (typeof(BehaviourTreeGraphNode).IsAssignableFrom(type) == false) return null;
            return base.GetNodeMenuName(type).Replace("BT/", "");
        }

        public override void OnGUI()
        {
            if (Selection.activeGameObject == null) return;
            var runner = Selection.activeGameObject.GetComponent<IAIBehaviourDebugger<BehaviourTreeGraph, BehaviourTreeState>>();
            if (runner != null)
            {
                NodeEditorWindow.current.Repaint();
            }
        }
    }
}