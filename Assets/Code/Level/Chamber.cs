using Code.Helpers;
using Code.Infrastructure.Repositories.Code.Infrastructure.Repositories;
using UnityEngine;

namespace Code.Level
{
    public class Chamber : MonoBehaviour
    {
        public Transform[] Exits;
        public float MaxDistance;

        private Cave Cave { get { return transform.parent.GetComponent<Cave>(); } }

        void Start()
        {
            CreateAnnexes();
        }

        void CreateAnnexes()
        {
            if (transform.position.magnitude < MaxDistance)
            {
                foreach (var e in Exits)
                {
                    PlaceCorridor(e);
                    Rooms.RoomCount++;
                }
            }
            else
            {
                foreach (var e in Exits)
                {
                    PlaceDeadEnd(e);
                }
            }
        }

        void PlaceDeadEnd(Transform exit)
        {
            var deadEndPf = Repos.SectionsRepo.GetRandomDeadEnd();
            var deadEnd = Instantiate(deadEndPf, exit.position, exit.rotation);
            deadEnd.transform.SetParent(Cave.transform);
        }

        void PlaceCorridor(Transform exit)
        {
            var corridorPf = Repos.SectionsRepo.GetRandomCorridor();
            var corridor = Instantiate(corridorPf, exit.position, exit.rotation);
            corridor.transform.SetParent(Cave.transform);

            if (!Cave.IsSectionValid(corridor.GetComponentsInChildren<Collider>(),
                GetComponentsInChildren<Collider>()))
            {
                PlaceDeadEnd(exit);
                Destroy(corridor);
            }
        }
    }
}
