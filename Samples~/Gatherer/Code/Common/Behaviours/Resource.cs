using System;
using UnityEngine;

namespace PlaniloSamples.Common
{
    public class Resource : MonoBehaviour
    {
        public int CarrierId { get; set; }
        public event Action<Resource> OnPicked;
        bool picked;

        public bool Pick()
        {
            if (picked) return false;

            OnPicked?.Invoke(this);
            picked = true;
            return true;
        }

        public void Consume() { }

        void OnEnable()
        {
            picked = false;
            CarrierId = 0;
        }
    }
}