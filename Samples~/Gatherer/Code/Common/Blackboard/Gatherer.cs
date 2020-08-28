using UnityEngine;

namespace PlaniloSamples.Common
{
    public struct Gatherer
    {
        public int Id;
        public Transform Transform;
        public Resource Resource;
        public Vector3 Target;
        public float Reach;
        public float Speed;

        public float LastRest;
        public float WorkTime;
        public float RestTime;

        public WorldState World;
    }
}