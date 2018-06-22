using UnityEngine;

namespace Code.UI
{
    public class MapExpand : MonoBehaviour
    {
        public float MaxSize;
        public float ScaleSpeed;

        private RectTransform rTransform;
        private float minSize;
        private bool isExpanding;

        private float size { get { return rTransform.sizeDelta.x; } }
        
        void Start()
        {
            rTransform = GetComponent<RectTransform>();
            minSize = size;
        }

        void Update()
        {
            if (isExpanding)
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
                var newSize = size + ScaleSpeed;
                rTransform.sizeDelta = new Vector2(newSize, newSize);
            }
        }

        void ScaleShrink()
        {
            if (size > minSize)
            {
                var newSize = size - ScaleSpeed;
                rTransform.sizeDelta = new Vector2(newSize, newSize);
            }
        }

        public void Expand()
        {
            isExpanding = true;
        }

        public void Shrink()
        {
            isExpanding = false;
        }
    }
}
