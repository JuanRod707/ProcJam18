using Code.Level;

namespace Code.Session
{
    public static class CaveData
    {
        public static Mineral[] AvailableMinerals { get; private set; }
        public static int CaveSize { get; private set; }

        static CaveData()
        {
            AvailableMinerals = new[] {Mineral.Blue, Mineral.Green};
            CaveSize = 10;
        }
    }
}
