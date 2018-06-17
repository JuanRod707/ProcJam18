using Code.Movement;
using UnityEngine;

namespace Code.PlayerInput
{
    public class KeyboardInput : MonoBehaviour
    {
        public EntityMovement MovingEntity;

        void FixedUpdate ()
        {
            var totalMovement = new Vector3(0f, Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

            if (totalMovement.magnitude > 0f)
            {
                MovingEntity.Move(totalMovement);
            }
        }
    }
}
