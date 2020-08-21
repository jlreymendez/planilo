namespace Planilo
{
    public interface IAIBehaviourRunner<TState>
    {
    #if UNITY_EDITOR
        TState[] GetState();
    #endif
    }
}