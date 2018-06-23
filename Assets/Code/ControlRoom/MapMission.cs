using Code.Helpers;

namespace Code.ControlRoom
{
    public class MapMission : Mission
    {
        private int roomsToMap;

        public string Description {
            get { return "Provide full topographic information of the cave"; }
        }

        public int Reward {
            get { return GameConfiguration.RoomMappingValue * roomsToMap; }
        }

        public bool IsComplete { get; private set; }

        public MapMission(int roomCount)
        {
            roomsToMap = roomCount;
        }

        public void CheckCompletion()
        {
            
        }
    }
}
