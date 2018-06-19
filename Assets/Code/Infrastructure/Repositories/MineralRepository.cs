using Code.Helpers;
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
    }
}
