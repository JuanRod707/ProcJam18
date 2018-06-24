using System;
using Code.Session;

namespace Code.IO.DataSchemas
{
    [Serializable]
    public class CharacterSave
    {
        public const string Filename = "Surveyor.xml";

        public static void Save(PlayerData player)
        {
            FileManagement.SaveFile(player, Filename);
        }

        public static bool IsSavePresent()
        {
            return FileManagement.CheckFile(Filename);
        }

        public static PlayerData Load()
        {
            return FileManagement.OpenSaves<PlayerData>(Filename) as PlayerData;
        }

        public static void Delete()
        {
            FileManagement.DeleteFile(Filename);
        }
    }
}
