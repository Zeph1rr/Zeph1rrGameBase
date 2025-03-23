namespace Zeph1rrGameBase.Scripts.Game2D.Monos
{
    public abstract class MonoInterlayer<T>: Game2D.Monos.Mono
    {
        public T ParentObject { get; private set; }

        public virtual void SetParentScript(T parentObject)
        {
            ParentObject = parentObject;
        }
    }
}
