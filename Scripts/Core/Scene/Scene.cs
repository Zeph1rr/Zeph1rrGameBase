using System.Linq;
using UnityEngine;

namespace Zeph1rrGameBase.Scripts.Core.Scene
{
    public class Scene
    {
        public string SceneName { get; }

        private ISceneEntryPoint _sceneEntryPoint;
        
        public Scene(string sceneName)
        {
            SceneName = sceneName;
        }

        public void StartScene()
        {
            var allMonoBehaviours = Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
            _sceneEntryPoint = allMonoBehaviours.OfType<ISceneEntryPoint>().FirstOrDefault();
            _sceneEntryPoint?.Run();
        }
    }
}