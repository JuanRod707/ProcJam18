using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.Repositories.Code.Infrastructure.Repositories;
using UnityEngine;

namespace Code.Level
{
    public class Cave : MonoBehaviour
    {
        private List<Collider> CaveSectionColliders = new List<Collider>();

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

        void RemoveSection(GameObject section)
        {
            var deadEnd = Instantiate(Repos.SectionsRepo.GetRandomDeadEnd(), section.transform.position, section.transform.rotation);
            deadEnd.transform.SetParent(transform);
            Destroy(section);
        }
    }
}
