using Code.Shrieks;
using Code.UI;
using UnityEngine;

namespace Code.Ship
{
    public class Hull : MonoBehaviour, Damageable
    {
        public float StartingHitPoints;
        public ParticleSystem LowHpEffect;
        public GameObject CarcassPrefab;
        public DeathPanel DeathReport;

        private bool isDead;
        
        private float warningThreshold {
            get { return StartingHitPoints / 3f; }
        }

        private float currentHitPoints;

        void Start()
        {
            currentHitPoints = StartingHitPoints;
        }

        public void ReceiveDamage(float damage)
        {
            if (!isDead)
            {
                currentHitPoints -= damage;

                if (currentHitPoints < warningThreshold)
                {
                    LowHpEffect.Play();
                }

                if (currentHitPoints <= 0)
                {
                    Kill();
                }
            }
        }

        void Kill()
        {
            Instantiate(CarcassPrefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            GameObject.Find("Player").SetActive(false);
            isDead = true;

            DeathReport.ShowDeathPanel();
        }
    }
}
