using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace Code.IO
{
    public static class FileManagement
    {
        private static string filePath = Application.dataPath + @"/Data/";

        public static object OpenSaves<T>(string fileName)
        {
            object result = null;

            try
            {
                using (var fs = File.Open(filePath + fileName, FileMode.OpenOrCreate))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    result = serializer.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }

            return result;
        }

        public static void DeleteFile(string fileName)
        {
            if (File.Exists(filePath + fileName))
            {
                File.Delete(filePath + fileName);
            }
        }

        public static bool CheckFile(string fileName)
        {
            return File.Exists(filePath + fileName);
        }

        public static void SaveFile<T>(T saveData, string fileName)
        {
            CreateFile(fileName);
            using (var sw = new StreamWriter(filePath + fileName))
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(sw, saveData);
                sw.Flush();
            }
        }

        private static void CreateFile(string fileName)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            if (!File.Exists(filePath + fileName))
            {
                var f = File.Create(filePath + fileName);
                f.Close();
            }
        }
    }
}
