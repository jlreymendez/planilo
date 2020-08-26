using Planilo.BT.Builder;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace Planilo.BT.Editor
{
    [CustomNodeEditor(typeof(BehaviourTreeSubGraphNode))]
    public class BehaviourTreeSubGraphNodeEditor : BehaviourTreeGraphNodeEditor
    {
        public override void OnHeaderGUI()
        {
            var name = target.name.Replace("Behaviour Tree Sub Graph", "Sub Tree");
            GUILayout.Label(name, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
        }
    }
}