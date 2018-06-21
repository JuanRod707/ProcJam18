using Code.Helpers;
using UnityEngine;

namespace Code.Infrastructure.Repositories
{
    public class SectionRepository : MonoBehaviour
    {
        public GameObject[] BigChambers;
        public GameObject[] SmallChambers;
        public GameObject[] Corridors;
        public GameObject[] DeadEnds;
        public GameObject[] Entrances;

        public GameObject GetRandomBigChamber()
        {
            return BigChambers.PickOne();
        }

        public GameObject GetRandomSmallChamber()
        {
            return SmallChambers.PickOne();
        }

        public GameObject GetRandomCorridor()
        {
            return Corridors.PickOne();
        }

        public GameObject GetRandomDeadEnd()
        {
            return DeadEnds.PickOne();
        }

        public GameObject GetRandomEntrance()
        {
            return Entrances.PickOne();
        }
    }
}
