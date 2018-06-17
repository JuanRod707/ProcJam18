using UnityEngine;

namespace Code.Movement
{
    public class EntityMovement : MonoBehaviour
    {
        public float MoveAcceleration;
        public float MaxSpeed;

        private Rigidbody myBody;
        
        void Start()
        {
            myBody = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 direction)
        {
            if (myBody.velocity.magnitude < MaxSpeed)
            {
                myBody.AddForce(direction * MoveAcceleration);
            }
        }
    }
}
