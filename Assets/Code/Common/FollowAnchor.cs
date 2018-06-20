using UnityEngine;

namespace Code.Common
{
    public class FollowAnchor : MonoBehaviour
    {
        public Transform Anchor;
        public float FollowSpeed;

        void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, Anchor.transform.position, FollowSpeed);
        }
    }
}
