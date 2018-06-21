using System.Collections.Generic;
using System.Linq;
using Code.Helpers;
using Code.Infrastructure.Repositories.Code.Infrastructure.Repositories;
using UnityEngine;

namespace Code.Level
{
    public class Cave : MonoBehaviour
    {
        public int RoomCount;

        private List<Collider> caveSectionColliders = new List<Collider>();
        private bool caveClosed;

        void Start()
        {
            Rooms.RoomCount = RoomCount;
            Instantiate(Repos.SectionsRepo.GetRandomBigChamber(), transform);
            var deadEnd = Instantiate(Repos.SectionsRepo.GetRandomDeadEnd(), transform);
            deadEnd.transform.eulerAngles = new Vector3(180f, 0f, 0f);
        }

        public void FinishCaveBuilding()
        {
            if (!caveClosed)
            {
                var topMostBounds = caveSectionColliders.OrderBy(x => x.transform.position.y).Last();
                var intersectingSections = caveSectionColliders.Where(x => x.bounds.Intersects(topMostBounds.bounds));
                var deadEnds = intersectingSections.Where(x => x.transform.parent.GetComponent<DeadEnd>() != null);
                var topChamber = topMostBounds.transform.parent;

                foreach (var de in deadEnds)
                {
                    Destroy(de.gameObject);
                }

                var entrance = Instantiate(Repos.SectionsRepo.GetRandomEntrance(), topChamber.position,
                    topChamber.rotation);
                entrance.transform.SetParent(transform);
                Destroy(topChamber.gameObject);
                caveClosed = true;
            }
        }

        public bool IsSectionValid(Collider sectionCollider, Collider colliderToIgnore)
        {
            foreach (var col in caveSectionColliders)
            {
                if (colliderToIgnore != col && sectionCollider.bounds.Intersects(col.bounds))
                {
                    return false;
                }
            }

            caveSectionColliders.Add(sectionCollider);
            return true;
        }

        public void DeadEndAdded(Collider[] sectionColliders)
        {
            caveSectionColliders.AddRange(sectionColliders);
        }
    }
}
