using Code.Common;
using UnityEngine;

namespace Code.Shrieks
{
    public class ShriekHead : MonoBehaviour, Damageable
    {
        public float StartingHealth;
        public float DistanceToDispose;
        public Rigidbody[] Bodies;
        public AudioClip DieSfx;

        private float currentHealth;
        private ShriekBrain brain;
        private Transform surveyor;
        private AudioSource audioPlayer;

        private bool isDead;

        private bool isFarFromPlayer {
            get { return Vector3.Distance(surveyor.position, transform.position) > DistanceToDispose; }
        }

        void Start()
        {
            brain = GetComponent<ShriekBrain>();
            currentHealth = StartingHealth;
            surveyor = GlobalReferences.Surveyor;
            audioPlayer = GetComponent<AudioSource>();
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
            if (!isDead)
            {
                currentHealth -= damage;
                if (currentHealth <= 0)
                {
                    Kill();
                }
            }
        }

        void Kill()
        {
            brain.enabled = false;
            foreach (var b in Bodies)
            {
                b.useGravity = true;
            }

            audioPlayer.clip = DieSfx;
            audioPlayer.Play();

            isDead = true;
        }
    }
}
