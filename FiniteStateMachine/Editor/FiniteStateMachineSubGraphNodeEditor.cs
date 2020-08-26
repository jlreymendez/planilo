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
    }
}
