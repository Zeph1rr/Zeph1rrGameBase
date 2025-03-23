using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Zeph1rrGameBase.Scripts.Core.SaveLoadSystem
{
    public class BinarySaveLoadSystem : FileSaveLoadSystem
    {
        public BinarySaveLoadSystem(string saveDirectory) : base(saveDirectory, "save")
        {
        }

        public override T Load<T>(string key, T defaultData)
        {
            var saveFilePath = GetSaveFilePath(key);
            if (!File.Exists(saveFilePath))
            {
                Debug.LogWarning("Save file not found! Returning default data");
                return defaultData;
            }

            using (FileStream fileStream = new(saveFilePath, FileMode.Open))
            {
                BinaryFormatter formatter = new();
                var data = (T)formatter.Deserialize(fileStream);
                return data;
            }
        }

        public override void Save<T>(string key, T data)
        {
            var saveFilePath = GetSaveFilePath(key);

            using (FileStream fileStream = new(saveFilePath, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new();
                formatter.Serialize(fileStream, data);

                Debug.Log($"Saved to {saveFilePath}");
            }
        }
    }
}