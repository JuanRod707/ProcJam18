using UnityEngine;

namespace Code.Common
{
    public class AutoDispose : MonoBehaviour
    {
        public float Lifespan;

        void Start()
        {
            Destroy(gameObject, Lifespan);
        }
    }
}
