using System.Collections.Generic;
using System.Linq;
using Code.Helpers;
using Code.Level;
using UnityEngine;

namespace Code.Infrastructure.Repositories
{
    public class MineralRepository : MonoBehaviour
    {
        public GameObject[] Minerals;

        public GameObject GetRandomMineralDeposit()
        {
            return Minerals.PickOne();
        }

        public GameObject GetFilteredMineralDeposit(IEnumerable<Mineral> mineralTypes)
        {
            return Minerals.Where(x => mineralTypes.Contains(x.GetComponent<MineralDeposit>().MineralColor)).PickOne();
        }
    }
}
