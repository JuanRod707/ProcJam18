using UnityEngine;

namespace Code.Movement
{
    public class ShriekMovement : MonoBehaviour
    {
        public float MoveAcceleration;
        public float RotationSpeed;

        private Rigidbody myBody;
        
        void Start()
        {
            myBody = GetComponent<Rigidbody>();
        }

        public void MoveForward()
        {
            myBody.AddForce(transform.forward * MoveAcceleration);
        }

        public void Pitch(float angle)
        {
            myBody.AddTorque(transform.right * angle);
        }

        void Update()
        {
            MoveForward();
            Pitch(RotationSpeed);
        }
    }
}
