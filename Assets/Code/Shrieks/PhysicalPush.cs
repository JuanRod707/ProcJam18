using UnityEngine;

namespace Code.Shrieks
{
    public class PhysicalPush : MonoBehaviour, Pushable
    {
        public float PushFactor = 1f;
        private Rigidbody myBody;

        void Start()
        {
            myBody = GetComponent<Rigidbody>();
        }

        public void Push(Vector3 fromPoint, float force)
        {
            var distance = Vector3.Distance(transform.position, fromPoint);
            var pushVector = transform.InverseTransformPoint(fromPoint).normalized;

            pushVector *= -force / distance;

            myBody.AddForce(pushVector * PushFactor);
        }
    }
}
