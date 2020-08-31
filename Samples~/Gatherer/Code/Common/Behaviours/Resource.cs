using System;
using UnityEngine;

namespace PlaniloSamples.Common
{
    public class Resource : MonoBehaviour
    {
        public int CarrierId { get; set; }
        public event Action<Resource> OnPicked;
        public event Action<Resource> OnConsumed;
        bool picked;
        bool consumed;

        public bool Pick()
        {
            if (picked) return false;

            picked = true;
            gameObject.SetActive(false);
            OnPicked?.Invoke(this);
            return true;
        }

        public void Drop(Vector3 position)
        {
            if (picked == false) return;

            transform.position = position;
            gameObject.SetActive(true);
        }

        public void Consume()
        {
            if (consumed) return;

            consumed = true;
            OnConsumed?.Invoke(this);
        }

        void OnEnable()
        {
            picked = false;
            consumed = false;
            CarrierId = 0;
        }
    }
}