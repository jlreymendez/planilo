using Planilo;
using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace PlaniloSamples.FSM
{
    public class GathererFSMRunner : MonoBehaviour,
        // Note: this is only required for debugging the agent in the planilo graph tool
        IAIBehaviourDebugger<FiniteStateMachineGraph, FiniteStateMachineRuntimeState>
    {
        [Header("General")]
        public FiniteStateMachineGraph BehaviourDefinition;

        [Header("Sample 01")]
        public float Speed;
        public float Reach;

        [Header("Sample 02")]
        public float WorkTime;
        public float RestTime;

        Gatherer agent = default;
        FiniteStateMachineRuntimeState fsmRuntimeState = default;
        IAIBehaviour<Gatherer, FiniteStateMachineRuntimeState> fsm = default;

        void Awake()
        {
            // We need to create an FSM based on the graph definition. And initialize the state for the agent.
            fsm = BehaviourDefinition.Build<Gatherer>();
            fsmRuntimeState = fsm.Initialize(ref agent);
        }

        void Start()
        {
            // Initialize agent on start once all required objects have initialized.
            agent.Id = GetInstanceID();
            agent.World.Home = FindObjectOfType<Home>().transform.position;
            agent.Speed = Speed;
            agent.Reach = Reach;
            agent.Transform = transform;
            agent.LastRest = Time.time;
            agent.WorkTime = WorkTime;
            agent.RestTime = RestTime;
        }
        void Update()
        {
            // Update agent sensors.
            agent.World.Resources = FindObjectsOfType<Resource>();
            // Execute finite state machine.
            // Every update we pass by reference the agent and the last state.
            fsm.Run(ref agent, ref fsmRuntimeState);
        }

    #if UNITY_EDITOR
        #region Editor
        public FiniteStateMachineRuntimeState GetState()
        {
            return fsmRuntimeState;
        }

        public FiniteStateMachineGraph GetBehaviour()
        {
            return BehaviourDefinition;
        }
        #endregion
    #endif
    }
}