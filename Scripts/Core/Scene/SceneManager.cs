using System;
using System.Collections;

namespace Zeph1rrGameBase.Scripts.Core.Scene
{
    public static class SceneManager
    {
        private static bool _sceneLoading;

        public static IEnumerator LoadSceneAsync(string sceneName, Action<Scene> callback = null)
        {
            if (_sceneLoading) yield break;
            _sceneLoading = true;
            yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            var scene = new Scene(sceneName);
            callback?.Invoke(scene);
            _sceneLoading = false;
        }
    }
}