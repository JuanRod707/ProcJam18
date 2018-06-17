using UnityEngine;

namespace Code.Common
{
    public class FollowAnchor : MonoBehaviour
    {
        public Transform Anchor;
        public float FollowSpeed;

        void Update()
        {
            transform.position = Vector3.Lerp(transform.position, Anchor.transform.position, FollowSpeed);
        }
    }
}
