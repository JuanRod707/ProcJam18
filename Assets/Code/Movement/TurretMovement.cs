using UnityEngine;

namespace Code.Movement
{
    public class TurretMovement : MonoBehaviour
    {
        public Transform AimPoint;

        void Update () {
		    transform.LookAt(AimPoint);
            var rotation = transform.eulerAngles;
            //rotation.y = 0f;
            rotation.z = 0f;

            transform.eulerAngles = rotation;
        }
    }
}
