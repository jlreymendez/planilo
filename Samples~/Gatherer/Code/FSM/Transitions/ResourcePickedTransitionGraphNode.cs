using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace PlaniloSamples.FSM
{
    public static class ResourcePickedTransition
    {
        public static bool Condition(Gatherer agent)
        {
            return agent.Resource != null && agent.Resource.CarrierId == agent.Id;
        }
    }

    [CreateNodeMenu("PlaniloSamples/FSM/Transitions/ResourcePicked")]
    public class ResourcePickedTransitionGraphNode : FiniteStateMachineTransitionGraphNode
    {
        public override FiniteStateMachineTransition<T> Build<T>(int targetIndex)
        {
            var transition = new FiniteStateMachineTransition<Gatherer>
            {
                Condition = ResourcePickedTransition.Condition,
                TargetState = targetIndex
            };
            return transition as FiniteStateMachineTransition<T>;
        }
    }
}