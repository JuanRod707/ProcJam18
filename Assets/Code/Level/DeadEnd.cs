using UnityEngine;

namespace Code.Level
{
    public class DeadEnd : MonoBehaviour
    {
        private Cave Cave { get { return transform.parent.GetComponent<Cave>(); } }

        void Start()
        {
            Cave.DeadEndAdded(GetComponentsInChildren<Collider>());
        }
    }
}
