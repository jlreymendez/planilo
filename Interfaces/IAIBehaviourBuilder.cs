namespace Planilo
{
    public interface IAIBehaviourBuilder<TState>
    {
        IAIBehaviour<TAgent, TState> Build<TAgent>();
    }
}