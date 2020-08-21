namespace Planilo
{
    public interface IAIBehaviourBuilder<K>
    {
        IAIBehaviour<T, K> Build<T>();
    }
}