using System;
using System.Collections;

namespace Zeph1rrGameBase.Scripts.Core.Scene
{
    public static class SceneManager
    {
        private static bool _sceneLoading;

        public static IEnumerator LoadSceneAsync(string sceneName, Action callback)
        {
            if (_sceneLoading) yield break;
            _sceneLoading = false;
            yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            var scene = new Scene(sceneName);
            scene.StartScene();
            callback.Invoke();
            _sceneLoading = true;
        }
    }
}