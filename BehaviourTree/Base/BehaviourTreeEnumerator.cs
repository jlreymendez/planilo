using System.Collections;
using System.Collections.Generic;

namespace Planilo.BT
{
    public struct BehaviourTreeEnumerator : IEnumerator<int>
    {
        int count;
        int index;

        public BehaviourTreeEnumerator(int count)
        {
            this.count = count;
            this.index = -1;
        }

        public bool MoveNext()
        {
            index++;
            return index < count;
        }

        public void Reset()
        {
            index = -1;
        }

        public int Current => index;

        object IEnumerator.Current => Current;

        public void Dispose() { }
    }
}