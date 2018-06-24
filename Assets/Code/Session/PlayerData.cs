using System;
using Code.Helpers.Generators;

namespace Code.Session
{
    [Serializable]
    public class PlayerData
    {
        public string Name { get; set; }
        public int Balance { get; set; }
        public int ServiceDays { get; set; }

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
