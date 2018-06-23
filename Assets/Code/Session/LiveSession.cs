using System.Collections.Generic;
using Code.ControlRoom;
using Code.Level;

namespace Code.Session
{
    public static class LiveSession
    {
        public static CaveData CaveData;
        public static Mission CurrentMission;
        public static PlayerData PlayerData;

        static LiveSession()
        {
            SetCaveData(5, new[] {Mineral.Blue, Mineral.White});
            SetPlayerData(new PlayerData());
            SetCurrentMission(new MapMission(0));
        }

        public static void SetCaveData(int size, IEnumerable<Mineral> materials)
        {
            CaveData = new CaveData(size, materials);
        }

        public static void SetCurrentMission(Mission mission)
        {
            CurrentMission = mission;
        }

        public static void SetPlayerData(PlayerData player)
        {
            PlayerData = player;
        }
    }
}
