using Zeph1rrGameBase.Scripts.Core.DI;

namespace Zeph1rrGameBase.Scripts.Core.Scene
{
    public interface ISceneEntryPoint
    {
        public void Initialize(DIContainer rootContainer);
        public void Run();
    }
}
