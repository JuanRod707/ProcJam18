using UnityEngine;

namespace Code.Weapons
{
    public class BarrelKick : MonoBehaviour
    {
        public float KickAmount;
        public float RecoveryFactor;

        private Vector3 originalPosition;

        void Start()
        {
            originalPosition = transform.localPosition;
        }

        void Update()
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, RecoveryFactor);
        }

        public void Kick()
        {
            transform.Translate(Vector3.back * KickAmount);
        }
    }
}
