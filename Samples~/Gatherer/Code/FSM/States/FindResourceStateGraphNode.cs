using System.Threading;
using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;
using UnityEngine;

namespace PlaniloSamples.FSM
{
    public class FindResourceState : FiniteStateMachineState<Gatherer>
    {
        public override void OnTick(ref Gatherer agent)
        {
            agent.Resource = null;

            var minDistance = float.MaxValue;
            foreach (var resource in agent.World.Resources)
            {
                var distance = Vector3.Distance(agent.Transform.position, resource.transform.position);
                if (resource.CarrierId == 0 && distance < minDistance)
                {
                    minDistance = distance;
                    agent.Resource = resource;
                    agent.Target = resource.transform.position;
                }
            }

            if (agent.Resource != null)
            {
                agent.Resource.CarrierId = agent.Id;
            }
        }
    }

    [CreateNodeMenu("PlaniloSamples/FSM/States/FindResource")]
    public class FindResourceStateGraphNode : FiniteStateMachineStateGraphNode
    {
        protected override FiniteStateMachineState<T> ProtectedBuild<T>()
        {
            return new FindResourceState() as FiniteStateMachineState<T>;
        }
    }
}