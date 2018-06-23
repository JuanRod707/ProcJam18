using Code.Helpers.Generators;

namespace Code.Session
{
    public class PlayerData
    {
        public string Name { get; private set; }
        public int Balance { get; private set; }
        public int ServiceDays { get; private set; }

        public PlayerData()
        {
            Name = NameGenerator.GenerateCharacterName();
            Balance = 0;
            ServiceDays = 0;
        }

        public PlayerData(string name, int balance, int days)
        {
            Name = name;
            Balance = balance;
            ServiceDays = days;
        }
    }
}
