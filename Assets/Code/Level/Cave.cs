using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.Repositories.Code.Infrastructure.Repositories;
using UnityEngine;

namespace Code.Level
{
    public class Cave : MonoBehaviour
    {
        private List<Collider> CaveSectionColliders = new List<Collider>();

        void Start()
        {
            Instantiate(Repos.SectionsRepo.GetRandomBigChamber(), transform);
            var deadEnd = Instantiate(Repos.SectionsRepo.GetRandomDeadEnd(), transform);
            deadEnd.transform.eulerAngles = new Vector3(180f, 0f, 0f);

            DeadEndAdded(deadEnd.GetComponentsInChildren<Collider>());
        }

        public bool IsSectionValid(Collider[] sectionColliders, Collider[] collidersToIgnore)
        {
            foreach (var colSection in sectionColliders)
            {
                foreach (var col in CaveSectionColliders)
                {
                    if (!collidersToIgnore.Contains(col) && colSection.bounds.Intersects(col.bounds))
                    {
                        return false;
                    }
                }                
            }

            CaveSectionColliders.AddRange(sectionColliders);
            return true;
        }

        public void DeadEndAdded(Collider[] sectionColliders)
        {
            CaveSectionColliders.AddRange(sectionColliders);
        }
    }
}
