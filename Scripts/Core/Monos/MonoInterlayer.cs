﻿namespace Zeph1rrGameBase.Scripts.Core.Monos
{
    public abstract class MonoInterlayer<T>: Mono
    {
        public T ParentObject { get; private set; }

        public virtual void SetParentScript(T parentObject)
        {
            ParentObject = parentObject;
        }
    }
}
