using Planilo.BT;

namespace Planilo
{
    public interface IAIBehaviour<T, K>
    {
        K[] Initialize(ref T agent);
        void Run(ref T agent, K[] state);
    }
}