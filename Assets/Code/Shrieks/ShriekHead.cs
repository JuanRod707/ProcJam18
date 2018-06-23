using Code.Common;
using UnityEngine;

namespace Code.Shrieks
{
    public class ShriekHead : MonoBehaviour, Damageable
    {
        public float StartingHealth;
        public float DistanceToDispose;
        public Rigidbody[] Bodies;

        private float currentHealth;
        private ShriekBrain brain;
        private Transform surveyor;

        private bool isDead;

        private bool isFarFromPlayer {
            get { return Vector3.Distance(surveyor.position, transform.position) > DistanceToDispose; }
        }

        void Start()
        {
            brain = GetComponent<ShriekBrain>();
            currentHealth = StartingHealth;
            surveyor = GlobalReferences.Surveyor;
        }

        void Update()
        {
            if (isDead && isFarFromPlayer)
            {
                foreach (var body in Bodies)
                {
                    if (body != null)
                        Destroy(body.gameObject);
                }
            }
        }

        public void ReceiveDamage(float damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Kill();
            }
        }

        void Kill()
        {
            brain.enabled = false;
            foreach (var b in Bodies)
            {
                b.useGravity = true;
            }

            isDead = true;
        }
    }
}
