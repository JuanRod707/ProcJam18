using UnityEngine;

namespace Code.UI
{
    public class Pointer : MonoBehaviour
    {
        void FixedUpdate ()
        {
            transform.position = Input.mousePosition;
        }
    }
}
