namespace Planilo
{
    public interface IAIBehaviourBuilder
    {
        IAIBehaviour<T> Build<T>();
    }
}