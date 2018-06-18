using UnityEngine;

namespace Code.Common
{
    public class ForwardMove : MonoBehaviour
    {
        public float MoveSpeed;

        void Update ()
        {
            transform.Translate(Vector3.forward * MoveSpeed);	
        }
    }
}
