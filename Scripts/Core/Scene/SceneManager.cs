using System;
using System.Collections;

namespace Zeph1rrGameBase.Scripts.Core.Scene
{
    public class SceneManager
    {
        private bool _sceneLoading;

        private readonly string[] _sceneNames;

        public SceneManager(string[] sceneNames)
        {
            _sceneNames = sceneNames;
        }

        public IEnumerator LoadSceneAsync(string sceneName, Action callback)
        {
            if (_sceneLoading) yield break;
            _sceneLoading = false;
            yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            var scene = new Core.Scene.Scene(sceneName);
            scene.StartScene();
            callback.Invoke();
            _sceneLoading = true;
        }
    }
}