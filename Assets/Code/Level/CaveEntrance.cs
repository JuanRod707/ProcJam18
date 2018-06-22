using UnityEngine;

namespace Code.Level
{
    public class CaveEntrance : MonoBehaviour
    {
        public Transform EntrancePoint;
        public Collider Bounds;
        public GameObject MiniMapSprite;
        
        void Start()
        {
            GameObject.Find("Surveyor").transform.position = EntrancePoint.position;
        }
    }
}
