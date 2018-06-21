using UnityEngine;

namespace Assets.Code.UI
{
    public class CaveMap : MonoBehaviour
    {
        public float Scale;

        public void AddSection(GameObject prefab, Transform origin)
        {
            var section = Instantiate(prefab, transform).transform;

            var pos = new Vector3(origin.localPosition.z, origin.localPosition.y, 0f);
            section.localPosition = pos / Scale;

            var rot = new Vector3(0f, 0f, -origin.localEulerAngles.x);
            section.localEulerAngles = rot;
        }
    }
}
