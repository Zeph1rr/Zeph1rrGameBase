using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace Zeph1rrGameBase.Scripts.Core.SaveLoadSystem
{
    public class Base64SaveLoadSystem : FileSaveLoadSystem
    {
        public Base64SaveLoadSystem(string saveDirectory) : base(saveDirectory, "save")
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
            var encodedData = File.ReadAllText(saveFilePath);
            var decodedBytes = Convert.FromBase64String(encodedData);
            var json = Encoding.UTF8.GetString(decodedBytes);
            var data = JsonUtility.FromJson<T>(json);
            return data;
        }

        public override void Save<T>(string key, T data)
        {
            var saveFilePath = GetSaveFilePath(key);

            var json = JsonUtility.ToJson(data, true);
            var bytes = System.Text.Encoding.UTF8.GetBytes(json);
            var encodedString = System.Convert.ToBase64String(bytes);
            File.WriteAllText(saveFilePath, encodedString);

            Debug.Log($"Data saved to {saveFilePath}");
        }
    }
}