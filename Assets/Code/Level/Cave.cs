using System.Collections.Generic;
using System.Linq;
using Code.Common;
using Code.Helpers;
using Code.Infrastructure.Repositories.Code.Infrastructure.Repositories;
using Code.Session;
using Code.UI;
using UnityEngine;

namespace Code.Level
{
    public class Cave : MonoBehaviour
    {
        public int RoomCount;
        public DynamicLabel PercentageExplored;

        private List<Collider> caveSectionColliders = new List<Collider>();
        private bool caveClosed;

        public float ExploredPercentage { get; private set; }

        private IEnumerable<Collider> chambers {
            get { return caveSectionColliders.Where(x => x.GetComponentInParent<Chamber>() != null); }
        }

        private IEnumerable<Collider> corridors
        {
            get { return caveSectionColliders.Where(x => x.GetComponentInParent<Corridor>() != null); }
        }

        private IEnumerable<Collider> deadEnds
        {
            get { return caveSectionColliders.Where(x => x.GetComponentInParent<DeadEnd>() != null); }
        }

        void Start()
        {
            RoomCount = 0;

            Instantiate(Repos.SectionsRepo.GetRandomBigChamber(), transform);
            var deadEnd = Instantiate(Repos.SectionsRepo.GetRandomDeadEnd(), transform);
            deadEnd.transform.eulerAngles = new Vector3(180f, 0f, 0f);
        }

        public void FinishCaveBuilding()
        {
            if (!caveClosed)
            {
                var topMostBounds = chambers.OrderBy(x => x.transform.position.y).Last();
                var intersectingSections = caveSectionColliders.Where(x => x.bounds.Intersects(topMostBounds.bounds));
                var deadEndsToRemove = intersectingSections.Where(x => x.transform.parent.GetComponent<DeadEnd>() != null);
                var topChamber = topMostBounds.transform.parent;

                foreach (var de in deadEndsToRemove)
                {
                    caveSectionColliders.Remove(de);
                    Destroy(de.gameObject);
                }

                var entrance = Instantiate(Repos.SectionsRepo.GetRandomEntrance(), topChamber.position, topChamber.rotation);
                entrance.transform.SetParent(transform);

                caveSectionColliders.Remove(topMostBounds);
                Destroy(topChamber.gameObject);

                var faultyDeadEnd =
                    deadEnds.FirstOrDefault(x => Vector3.Distance(x.transform.position, GlobalReferences.Surveyor.position) < 50);
                if (faultyDeadEnd != null)
                {
                    caveSectionColliders.Remove(faultyDeadEnd);
                    Destroy(faultyDeadEnd.gameObject);
                }

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

        public void DeadEndAdded(Collider sectionCollider)
        {
            caveSectionColliders.Add(sectionCollider);
        }

        public void DiscoveredSection()
        {
            var sections = caveSectionColliders.Select(x => x.GetComponent<SectionBounds>()).ToArray();
            var exploredCount = sections.Count(x => x.HasBeenMapped);
            ExploredPercentage = (float)exploredCount / (float)sections.Count() * 100f;

            PercentageExplored.SetLabel(ExploredPercentage.ToString("0"));
            LiveSession.CurrentMission.CheckCompletion();    
        }
    }
}
