using System.Linq;
using Code.Level;
using Code.Session;
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
            Mutate();
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

        void Mutate()
        {
            if (LiveSession.CaveData.AvailableMinerals.Contains(Mineral.Red))
            {
                MoveSpeed += MoveSpeed / 2;
                ChargeSpeed += ChargeSpeed / 2;

                if (LiveSession.CaveData.AvailableMinerals.Contains(Mineral.Red))
                {
                    MoveSpeed += MoveSpeed / 2;
                    ChargeSpeed += ChargeSpeed / 2;
                }
            }
        }
    }
}
