using Planilo.FSM;
using Planilo.FSM.Builder;
using PlaniloSamples.Common;

namespace PlaniloSamples.FSM
{
    public class GoHomeState : MoveToTargetState
    {
        public override void OnEnter(ref Gatherer agent)
        {
            agent.Target = agent.World.Home;
        }
    }

    [CreateNodeMenu("PlaniloSamples/FSM/States/GoHome")]
    public class GoHomeStateGraphNode : FiniteStateMachineStateGraphNode
    {
        protected override FiniteStateMachineState<T> ProtectedBuild<T>()
        {
            return new GoHomeState() as FiniteStateMachineState<T>;
        }
    }
}