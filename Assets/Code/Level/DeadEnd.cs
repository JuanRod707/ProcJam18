using UnityEngine;

namespace Code.Level
{
    public class DeadEnd : MonoBehaviour
    {
        public Collider Bounds;
        private Cave Cave { get { return transform.parent.GetComponent<Cave>(); } }

        void Start()
        {
            Cave.DeadEndAdded(Bounds);
        }
    }
}
