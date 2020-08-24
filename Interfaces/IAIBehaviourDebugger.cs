namespace Planilo
{
    public interface IAIBehaviourDebugger<TBehaviour, TState>
    {
    #if UNITY_EDITOR
        TState[] GetState();
        TBehaviour GetBehaviour();
    #endif
    }
}