using Assets.Code.Common;
using Code.Helpers;
using Code.Infrastructure.Repositories.Code.Infrastructure.Repositories;
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
            GlobalReferences.CaveMap.AddSection(MiniMapSprite, transform);
            GameObject.Find("Surveyor").transform.position = EntrancePoint.position;
        }
    }
}
