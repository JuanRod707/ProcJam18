using Code.Cameras;
using Code.Movement;
using Code.Ship;
using Code.UI;
using Code.Weapons;
using UnityEngine;

namespace Code.PlayerInput
{
    public class KeyboardInput : MonoBehaviour
    {
        public EntityMovement MovingEntity;
        public SurveyorSystems Systems;
        public MapExpand MapExpand;
        public MapCamera MapCamera;

        private bool mapExpanded;

        void Update ()
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

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (mapExpanded)
                {
                    MapExpand.Shrink();
                    MapCamera.ZoomIn();
                }
                else
                {
                    MapExpand.Expand();
                    MapCamera.ZoomOut();
                }

                mapExpanded = !mapExpanded;
            }
        }
    }
}
