using Planilo.FSM.Builder;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace Planilo.FSM.Editor
{
    [CustomNodeEditor(typeof(FiniteStateMachineTransitionGraphNode))]
    public class FiniteStateMachineGraphNodeEditor : NodeEditor
    {
        public override void OnHeaderGUI()
        {
            var name = target.name.Replace("Transition Graph", "");
            GUILayout.Label(name, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
        }
    }
}
