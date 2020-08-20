namespace Planilo
{
    public interface IAIBehaviour<T>
    {
        void Run(T agent);
    }
}