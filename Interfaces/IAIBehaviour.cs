using Planilo.BT;

namespace Planilo
{
    public interface IAIBehaviour<TAgent, TState>
    {
        TState[] Initialize(ref TAgent agent);
        void Run(ref TAgent agent, TState[] state);
    }
}