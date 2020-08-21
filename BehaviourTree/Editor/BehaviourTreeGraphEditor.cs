using System.ComponentModel;
using Planilo.BT.Builder;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace Planilo.BT.Editor
{
    [CustomNodeGraphEditor(typeof(BehaviourTreeGraph))]
    public class BehaviourTreeGraphEditor : NodeGraphEditor
    {
        public override void OnGUI()
        {
            var runner = Selection.activeGameObject != null ?
                Selection.activeGameObject.GetComponent<IAIBehaviourRunner<BehaviourTreeState>>() : null;
            if (runner != null)
            {
                NodeEditorWindow.current.Repaint();
            }
        }
    }
}