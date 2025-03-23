using System.IO;
using UnityEngine;

namespace Zeph1rrGameBase.Scripts.Core.SaveLoadSystem
{
    public class JsonSaveLoadSystem: FileSaveLoadSystem
    {
        public JsonSaveLoadSystem(string saveDirectory) : base(saveDirectory, "json")
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
            var json = File.ReadAllText(saveFilePath);
            var data = JsonUtility.FromJson<T>(json);
            return data;
        }

        public override void Save<T>(string key, T data)
        {
            var saveFilePath = GetSaveFilePath(key);

            var json = JsonUtility.ToJson(data, true);
            File.WriteAllText(saveFilePath, json);

            Debug.Log($"Data saved to {saveFilePath}");
        }
    }
}