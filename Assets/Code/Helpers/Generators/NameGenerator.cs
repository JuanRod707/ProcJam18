using System;
using Random = UnityEngine.Random;

namespace Code.Helpers.Generators
{
    public static class NameGenerator
    {
        private static string[] FirtNames = { "John", "Kun", "Takeshi", "Victor", "Bruce", "Andrew", "Santiago", "Igor", "Katya", "Anna", "Carina", "Lin", "Cassie", "Boris", "Ruolf", "Mary", "Maria", "Anya", "Kate", "Sebastian", "Damien", "Oslo", "Ricardo", "Vincent", "William", "Anastasia", "Esther", "Tarja", "Elise", "Ivana", "Kao", "Rodrigo", "Ismael", "Alvaro" };
        private static string[] LastNames = { "Rodriguez", "Richardson", "Kovackz", "Stow", "Serrada", "Noguera", "Sallieri", "Benz", "Nazaki", "Lee", "Strongman", "Pereira", "Silveira", "Mendez", "Smith", "Nguyen", "Gond", "Ferndandez", "Yeltsin", "Aksenova", "Volstok", "Percivall", "Shaw", "Park", "Ochoa", "Modric", "Bastout", "Lucien", "Despaux", "Correa", "Hummels" };
        private static string[] CavePrefixes = {"NGD", "CVK", "DFF", "NDH", "SOC", "CGQ", "KLV", "WKL", "HUJ"};
        
        public static string GenerateCharacterName()
        {
            return string.Format("{0} {1}", FirtNames.PickOne(), LastNames.PickOne());
        }

        public static string GenerateCaveName()
        {
            return string.Format("{0}-{1}", CavePrefixes.PickOne(), Random.Range(100, 800));
        }
    }
}
