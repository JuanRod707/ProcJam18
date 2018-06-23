using UnityEngine;

namespace Code.Shrieks
{
    public interface Pushable
    {
        void Push(Vector3 from, float force);
    }
}
