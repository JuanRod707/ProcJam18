using UnityEngine;

namespace Code.UI
{
    public class Pointer : MonoBehaviour
    {
        private RectTransform myRect;

        void Start()
        {
            myRect = this.GetComponent<RectTransform>();
            Cursor.visible = false;
        }

        void Update()
        {
            myRect.position = Input.mousePosition;
        }
    }
}
