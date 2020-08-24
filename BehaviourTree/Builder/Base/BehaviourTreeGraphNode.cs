using System;
using XNode;
using UnityEngine;

namespace Planilo.BT.Builder
{
    public abstract class BehaviourTreeGraphNode : Node
    {
        #region Public
        public bool IsRoot
        {
            get => isRoot;
            set => isRoot = value;
        }

        public BehaviourTreeNode<T> Build<T>(ref int index)
        {
        #if UNITY_EDITOR
            if (IsRoot == false)
            {
                var parentNode = GetInputPort("parent").Connection.node as BehaviourTreeGraphNode;
                BuildingGraph = parentNode.BuildingGraph;
            }

            BuildingGraph.SetNodeIndex(GetInstanceID(), index + 1);
        #endif

            if (AllowedType == null || AllowedType.IsAssignableFrom(typeof(T)))
            {
                index++;
                Index = index;
                return ProtectedBuild<T>(ref index);
            }

            return null;
        }

        [ContextMenu("Set as root")]
        public void SetAsRoot()
        {
            BehaviourTreeGraph btGraph = graph as BehaviourTreeGraph;
            btGraph.SetRoot(this);

            NodePort port = GetInputPort("parent");
            port.Disconnect(port.Connection);
        }

        public virtual int Size => 1;
        public int Index { get; set; }

        public override object GetValue(NodePort port)
        {
            return null;
        }
        #endregion

        #region Protected

        protected virtual string NiceName => "";

        protected virtual Type AllowedType => null;

        protected abstract BehaviourTreeNode<T> ProtectedBuild<T>(ref int index);

        protected override void Init()
        {
            Index = -1;
            name = string.IsNullOrEmpty(NiceName) ? name : NiceName;
        }
        #endregion

        #region Private
        [SerializeField, HideInInspector] bool isRoot;
        [SerializeField, Input] BehaviourTreeGraphConnection parent;
        #endregion

    #if UNITY_EDITOR
        #region Editor
        public BehaviourTreeGraph BuildingGraph { get; set; }
        #endregion
    #endif
    }
}
