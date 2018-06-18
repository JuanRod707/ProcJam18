using UnityEngine;

namespace Code.UI
{
    public class Pointer : MonoBehaviour
    {
        void Update ()
        {
            transform.position = Input.mousePosition;
        }
    }
}
