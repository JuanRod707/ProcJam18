using Code.Shrieks;
using UnityEngine;

namespace Code.Weapons
{
    public class PlasmaShot : MonoBehaviour
    {
        public float Damage;
        public float PushForce;
        public GameObject HitPrefab;

        private void OnTriggerEnter(Collider other)
        {
            var pushable = other.GetComponent<Pushable>();
            if(pushable != null)
            {
                pushable.Push(transform.position, PushForce);
            }

            var damageable = other.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.ReceiveDamage(Damage);
            }

            Instantiate(HitPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
