using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace PlaniloSamples.FSM
{
    public static class ResourceUnavailableTransition
    {
        public static bool Condition(Gatherer agent)
        {
            return agent.Resource == null ||
                Vector3.Distance(agent.Transform.position, agent.Target) > agent.Reach ||
                (agent.Resource.CarrierId != 0 && agent.Resource.CarrierId != agent.Id);
        }
    }

    [CreateNodeMenu("PlaniloSamples/FSM/Transitions/ResourceUnavailable")]
    public class ResourceUnavailableTransitionGraphNode : FiniteStateMachineTransitionGraphNode
    {
        public override FiniteStateMachineTransition<T> Build<T>(int targetIndex)
        {
            var transition = new FiniteStateMachineTransition<Gatherer>
            {
                Condition = ResourceUnavailableTransition.Condition,
                TargetState = targetIndex
            };
            return transition as FiniteStateMachineTransition<T>;
        }
    }
}