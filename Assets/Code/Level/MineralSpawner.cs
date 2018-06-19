using Code.Infrastructure.Repositories.Code.Infrastructure.Repositories;
using UnityEngine;

namespace Code.Level
{
    public class MineralSpawner : MonoBehaviour
    {
        public int SpawnChance;
        public Transform[] SpawnPoints;

        void Start()
        {
            GenerateDeposits();
        }

        void GenerateDeposits()
        {
            foreach (var sp in SpawnPoints)
            {
                if (Random.Range(0, 100) < SpawnChance)
                {
                    Instantiate(Repos.MineralsRepo.GetRandomMineralDeposit(), sp);
                }
            }
        }
    }
}
