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
            var normalCount = spawnPoints.Count() * GameConfiguration.NormalSpawnMultiplier;
            var spawnCandidates = spawnPoints.Take((int)normalCount);

            if (LiveSession.CaveData.AvailableMinerals.Contains(Mineral.White))
            {
                spawnCandidates = spawnPoints;
            }

            foreach (var sp in spawnCandidates)
            {
                var shriek = Instantiate(Repos.ShrieksRepo.GetRandomShriek(), sp.position, Quaternion.identity)
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
