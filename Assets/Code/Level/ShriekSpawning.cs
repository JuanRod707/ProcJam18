using System.Collections.Generic;
using System.Linq;
using Code.Common;
using Code.Helpers;
using Code.Infrastructure.Repositories.Code.Infrastructure.Repositories;
using Code.Session;
using UnityEngine;

namespace Code.Level
{
    public class ShriekSpawning : MonoBehaviour
    {
        IEnumerable<Transform> spawnPoints
        {
            get { return GetComponentsInChildren<Transform>().Where(x => x != transform); }
        }

        private bool hasSpawned;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (hasSpawned)
                    SpawnConsecutives();
                else
                    SpawnFirstTime();
            }
        }

        void SpawnFirstTime()
        {
            var spawns = spawnPoints.ToArray();

            var maxSpawns = (int)(spawns.Length * GameConfiguration.NormalSpawnMultiplier);

            if (LiveSession.CaveData.AvailableMinerals.Contains(Mineral.White))
            {
                maxSpawns = spawns.Length;
            }

            var shrieksToSpawn = Random.Range(0, maxSpawns);

            for (int i = 0; i < shrieksToSpawn; i++)
            {
                var shriek = Instantiate(Repos.ShrieksRepo.GetRandomShriek(), spawns[i].position, Quaternion.identity)
                    .transform;
                shriek.SetParent(GlobalReferences.ShriekContainer);
            }

            hasSpawned = true;
        }

        void SpawnConsecutives()
        {
            if (MathHelper.ChanceD100(GameConfiguration.ChancesOfRespawn))
            {
                SpawnFirstTime();
            }
        }
    }
}
