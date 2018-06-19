using Code.Infrastructure.Repositories.Code.Infrastructure.Repositories;
using UnityEngine;

namespace Code.Level
{
    public class Corridor : MonoBehaviour
    {
        public Transform[] Exits;
        public Collider Bounds;

        private Cave Cave { get { return transform.parent.GetComponent<Cave>(); } }

        void Start()
        {
            CreateAnnexes();
        }

        void CreateAnnexes()
        {
            foreach (var e in Exits)
            {
                PlaceChamber(e);
            }
        }

        void PlaceDeadEnd(Transform exit)
        {
            var deadEndPf = Repos.SectionsRepo.GetRandomDeadEnd();
            var deadEnd = Instantiate(deadEndPf, exit.position, exit.rotation);
            deadEnd.transform.SetParent(Cave.transform);
        }

        void PlaceChamber(Transform exit)
        {
            var chamberPf = Random.Range(0, 10) > 1 ?
                Repos.SectionsRepo.GetRandomSmallChamber() :
                Repos.SectionsRepo.GetRandomBigChamber();
            var chamber = Instantiate(chamberPf, exit.position, exit.rotation).GetComponent<Chamber>();
            chamber.transform.SetParent(Cave.transform);

            if (!Cave.IsSectionValid(chamber.Bounds, Bounds))
            {
                PlaceDeadEnd(exit);
                Destroy(chamber.gameObject);
            }
        }
    }
}
