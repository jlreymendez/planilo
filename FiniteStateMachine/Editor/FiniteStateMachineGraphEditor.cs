using System;
using Planilo.FSM.Builder;
using UnityEditor;
using XNodeEditor;

namespace Planilo.FSM.Editor
{
    [CustomNodeGraphEditor(typeof(FiniteStateMachineGraph))]
    public class FiniteStateMachineGraphEditor : NodeGraphEditor
    {
        public override string GetNodeMenuName(Type type)
        {
            if (typeof(FiniteStateMachineStateGraphNode).IsAssignableFrom(type) == false &&
                typeof(FiniteStateMachineTransitionGraphNode).IsAssignableFrom(type) == false)
            {
                return null;
            }
            return base.GetNodeMenuName(type).Replace("FSM/", "");
        }

        public override void OnGUI()
        {
            if (Selection.activeGameObject == null) return;
            var runner = Selection.activeGameObject.GetComponent<IAIBehaviourDebugger<FiniteStateMachineGraph, FiniteStateMachineRuntimeState>>();
            if (runner != null)
            {
                NodeEditorWindow.current.Repaint();
            }
        }
    }
}