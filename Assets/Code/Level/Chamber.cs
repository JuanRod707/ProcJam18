using Code.Common;
using Code.Helpers;
using Code.Infrastructure.Repositories.Code.Infrastructure.Repositories;
using Code.Session;
using UnityEngine;

namespace Code.Level
{
    public class Chamber : MonoBehaviour
    {
        public Transform[] Exits;
        public Collider Bounds;
        public GameObject MiniMapSprite;

        private Cave Cave { get { return transform.parent.GetComponent<Cave>(); } }

        void Start()
        {
            CreateAnnexes();
        }

        void CreateAnnexes()
        {
            if (Cave.RoomCount < LiveSession.CaveData.CaveSize)
            {
                foreach (var e in Exits)
                {
                    PlaceCorridor(e);
                    Cave.RoomCount++;
                }
            }
            else
            {
                foreach (var e in Exits)
                {
                    PlaceDeadEnd(e);
                }

                if (Cave.RoomCount >= LiveSession.CaveData.CaveSize)
                {
                    Cave.FinishCaveBuilding();
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
            var corridor = Instantiate(corridorPf, exit.position, exit.rotation).GetComponent<Corridor>();
            corridor.transform.SetParent(Cave.transform);

            if (!Cave.IsSectionValid(corridor.Bounds, Bounds))
            {
                PlaceDeadEnd(exit);
                Destroy(corridor.gameObject);
            }
        }
    }
}
