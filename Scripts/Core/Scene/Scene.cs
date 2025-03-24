using System.Linq;
using UnityEngine;
using Zeph1rrGameBase.Scripts.Core.DI;

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

        public void Initialize(DIContainer rootContainer)
        {
            var allMonoBehaviours = Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
            _sceneEntryPoint = allMonoBehaviours.OfType<ISceneEntryPoint>().FirstOrDefault();
            _sceneEntryPoint.Initialize(rootContainer);
        }

        public void StartScene()
        {
            _sceneEntryPoint?.Run();
        }
    }
}