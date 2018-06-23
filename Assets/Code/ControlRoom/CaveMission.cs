using System;
using System.Collections.Generic;
using System.Linq;
using Code.Helpers;
using Code.Helpers.Generators;
using Code.Level;
using Random = UnityEngine.Random;

namespace Code.ControlRoom
{
    public struct CaveMission
    {
        public string CaveName;
        public CaveSize CaveSize;
        public IEnumerable<Mineral> CaveMinerals;
        public Mission Mission;
        public int CaveRooms;

        public static CaveMission GenerateCaveMission()
        {
            var caveMission = new CaveMission
            {
                CaveName = NameGenerator.GenerateCaveName(),
                CaveSize = (CaveSize) Random.Range(0, 3),
                CaveMinerals = GenerateMinerals()
            };

            caveMission.CaveRooms = MathHelper.SelectFromRange(GameConfiguration.CaveSizeRooms[caveMission.CaveSize]);
            caveMission.Mission = GenerateMission(caveMission);

            return caveMission;
        }

        private static Mission GenerateMission(CaveMission caveMission)
        {
            if (MathHelper.RollD2())
            {
                return new MapMission(caveMission.CaveRooms);
            }
            else
            {
                return new MiningMission(caveMission.CaveMinerals);
            }
        }

        static IEnumerable<Mineral> GenerateMinerals()
        {
            var mineralCount = MathHelper.ChanceD100(GameConfiguration.ExtraMineralChance) ? 3 : 2;
            var allMinerals = Enumerable.Range(0, Enum.GetNames(typeof(Mineral)).Length).Select(x => (Mineral)x).ToList();
            var minerals = new List<Mineral>();

            while (mineralCount > 0)
            {
                var mineralToAdd = allMinerals.PickOne();
                minerals.Add(mineralToAdd);
                allMinerals.Remove(mineralToAdd);

                mineralCount--;
            }

            return minerals;
        }
    }
}
