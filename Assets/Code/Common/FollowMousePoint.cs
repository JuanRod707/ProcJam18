using UnityEngine;

namespace Code.Common
{
    public class FollowMousePoint : MonoBehaviour
    {
        public float Distance;
        public float AimSpeed;

        private Camera viewPort;
        private float forcedX;
        
        void Start()
        {
            forcedX = transform.parent.position.x;
            viewPort = Camera.main;
        }

        void Update ()
        {
            var ray = viewPort.ScreenPointToRay(Input.mousePosition);
            var point = ray.GetPoint(Distance);
            point.x = forcedX;

            transform.position = Vector3.Lerp(transform.position, point, AimSpeed);
        }
    }
}
