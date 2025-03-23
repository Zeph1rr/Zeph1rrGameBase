using UnityEngine;

namespace Zeph1rrGameBase.Scripts.Core.SaveLoadSystem
{
    public class PlayerPrefsSaveLoadSystem : Core.SaveLoadSystem.SaveLoadSystem
    {
        public override void Save<T>(string key, T data)
        {
            var json = JsonUtility.ToJson(data, true);
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();
        }

        public override T Load<T>(string key, T defaultData)
        {
            var json = PlayerPrefs.GetString(key, string.Empty);
            return string.IsNullOrEmpty(json) ? defaultData : JsonUtility.FromJson<T>(json);
        }
    }
}