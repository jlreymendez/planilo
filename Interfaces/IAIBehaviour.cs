using Planilo.BT;

namespace Planilo
{
    public interface IAIBehaviour<T>
    {
        BehaviourTreeState[] Initialize(ref T agent);
        BehaviourTreeState[] Run(ref T agent, BehaviourTreeState[] state);
    }
}