using Code.Movement;
using Code.Ship;
using Code.Weapons;
using UnityEngine;

namespace Code.PlayerInput
{
    public class KeyboardInput : MonoBehaviour
    {
        public EntityMovement MovingEntity;
        public SurveyorSystems Systems;

        void FixedUpdate ()
        {
            var totalMovement = new Vector3(0f, Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

            if (totalMovement.magnitude > 0f)
            {
                MovingEntity.Move(totalMovement);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Systems.SwitchMode();
            }
        }
    }
}
