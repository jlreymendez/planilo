namespace PlaniloSamples.Common
{
    public interface IBehaviourManager<TBehaviourGraph, TBehaviourState>
    {
        TBehaviourGraph BehaviourGraph { get; }

        TBehaviourState GetAgentState(int index);
    }
}