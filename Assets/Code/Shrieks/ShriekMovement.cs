using UnityEngine;

namespace Code.Shrieks
{
    public class ShriekMovement : MonoBehaviour
    {
        public float MoveSpeed;
        public float ChargeSpeed;
        public float RotationSpeed;

        private Rigidbody myBody;

        public void Start()
        {
            myBody = GetComponent<Rigidbody>();
        }

        public void MoveForward()
        {
            myBody.AddForce(transform.forward * MoveSpeed);
        }

        public void Charge()
        {
            myBody.AddForce(transform.forward * ChargeSpeed);
        }

        public void TurnRight()
        {
            myBody.AddTorque(transform.right * RotationSpeed);
        }

        public void TurnLeft()
        {
            myBody.AddTorque(transform.right * -RotationSpeed);
        }
    }
}
