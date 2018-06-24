using System.Linq;
using Code.Ship;
using UnityEngine;

namespace Code.Shrieks
{
    public class ShriekAttack : MonoBehaviour
    {
        public float DamageModifier;
        public float MinimumVelocity;
        public GameObject HitEffect;

        private Rigidbody myBody;

        void Start()
        {
            myBody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            var hull = collision.collider.GetComponent<Hull>();
            if (hull != null && myBody.velocity.magnitude > MinimumVelocity)
            {
                hull.ReceiveDamage(myBody.velocity.magnitude * DamageModifier);
                Instantiate(HitEffect, collision.contacts.First().point, Quaternion.identity);
            }
        }
    }
}
