using UnityEngine;

namespace Code.Cameras
{
    public class MapCamera : MonoBehaviour
    {
        public float MaxSize;
        public float ZoomSpeed;

        private float minSize;
        private bool isZoomingOut;
        private Camera camera;

        private float size { get { return camera.orthographicSize; } }

        void Start()
        {
            camera = GetComponent<Camera>();
            minSize = camera.orthographicSize;
        }

        void Update()
        {
            if (isZoomingOut)
            {
                ScaleExpand();
            }
            else
            {
                ScaleShrink();
            }
        }

        void ScaleExpand()
        {
            if (size < MaxSize)
            {
                var newSize = size + ZoomSpeed;
                camera.orthographicSize = newSize;
            }
        }

        void ScaleShrink()
        {
            if (size > minSize)
            {
                var newSize = size - ZoomSpeed;
                camera.orthographicSize = newSize;
            }
        }

        public void ZoomOut()
        {
            isZoomingOut = true;
        }

        public void ZoomIn()
        {
            isZoomingOut = false;
        }
    }
}
