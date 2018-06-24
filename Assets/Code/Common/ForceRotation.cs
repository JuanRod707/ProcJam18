using UnityEngine;

namespace Code.Common
{
    public class ForceRotation : MonoBehaviour
    {
        public Vector3 ForceEuler;

        void Start()
        {
            transform.eulerAngles = ForceEuler;
        }
    }
}
