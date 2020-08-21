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
            if (AllowedType == null || AllowedType.IsAssignableFrom(typeof(T)))
            {
                index++;
                Index = index;
                return ProtectedBuild<T>(ref index);
            }

            Debug.LogError("Attempting to build node with wrong generic type.");
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
    }
}
