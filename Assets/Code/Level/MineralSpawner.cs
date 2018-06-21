using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.Repositories.Code.Infrastructure.Repositories;
using Code.Session;
using UnityEngine;

namespace Code.Level
{
    public class MineralSpawner : MonoBehaviour
    {
        public int SpawnChance;
        IEnumerable<Transform> spawnPoints;

        void Start()
        {
            spawnPoints = GetComponentsInChildren<Transform>().Where(x => x != transform);
            GenerateDeposits();
        }

        void GenerateDeposits()
        {
            foreach (var sp in spawnPoints)
            {
                if (Random.Range(0, 100) < SpawnChance)
                {
                    Instantiate(Repos.MineralsRepo.GetFilteredMineralDeposit(CaveData.AvailableMinerals), sp);
                }
            }
        }
    }
}
