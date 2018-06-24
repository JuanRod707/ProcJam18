using System.Collections.Generic;
using Code.ControlRoom;
using Code.Level;

namespace Code.Helpers
{
    public static class GameConfiguration
    {
        public static int ExtraMineralChance = 5;
        public static float ExtractionMissionMultiplier = 1.5f;
        public static int RoomMappingValue = 1500;
        public static float NormalSpawnMultiplier = 0.5f;
        public static int ChancesOfRespawn = 20;
        public static int ChancesOfMapMission = 30;
        public static FloatRange MineralExtractionRange = new FloatRange(20, 200);

        public static Dictionary<CaveSize, IntRange> CaveSizeRooms;
        public static Dictionary<Mineral, int> MineralValues;
        public static Dictionary<Mineral, string> MineralDisplay;

        static GameConfiguration()
        {
            LoadCaveSizes();
            LoadMineralValues();
            LoadMineralDisplay();
        }

        static void LoadCaveSizes()
        {
            CaveSizeRooms = new Dictionary<CaveSize, IntRange>();
            CaveSizeRooms.Add(CaveSize.Small, new IntRange(3, 5));
            CaveSizeRooms.Add(CaveSize.Medium, new IntRange(5, 9));
            CaveSizeRooms.Add(CaveSize.Big, new IntRange(8, 15));
            CaveSizeRooms.Add(CaveSize.Huge, new IntRange(14, 21));
        }

        static void LoadMineralValues()
        {
            MineralValues = new Dictionary<Mineral, int>();

            MineralValues.Add(Mineral.White, 6);
            MineralValues.Add(Mineral.Green, 11);
            MineralValues.Add(Mineral.Red, 18);
            MineralValues.Add(Mineral.Blue, 32);
            MineralValues.Add(Mineral.Yellow, 50);
        }

        static void LoadMineralDisplay()
        {
            MineralDisplay = new Dictionary<Mineral, string>();

            MineralDisplay.Add(Mineral.White, "<color=#C3C3C3>Harenite</color>");
            MineralDisplay.Add(Mineral.Green, "<color=#00AB37>Polonite</color>");
            MineralDisplay.Add(Mineral.Red, "<color=#AB2B00>Adrenium</color>");
            MineralDisplay.Add(Mineral.Blue, "<color=#0047AB>Thordenite</color>");
            MineralDisplay.Add(Mineral.Yellow, "<color=#ABA800>Stronium</color>");
        }
    }
}
