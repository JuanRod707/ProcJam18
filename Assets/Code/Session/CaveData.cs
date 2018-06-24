using System.Collections.Generic;
using Code.Level;

namespace Code.Session
{
    public class CaveData
    {
        public IEnumerable<Mineral> AvailableMinerals { get; private set; }
        public int CaveSize { get; private set; }
        public string Name { get; private set; }

        public CaveData(string name, int size, IEnumerable<Mineral> minerals)
        {
            Name = name;
            AvailableMinerals = minerals;
            CaveSize = size;
        }
    }
}
