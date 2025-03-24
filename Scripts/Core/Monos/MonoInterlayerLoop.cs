using System;

namespace Zeph1rrGameBase.Scripts.Core.Monos
{
    public abstract class MonoInterlayerLoop<T> : MonoInterlayer<T>
    {
        private Action _loop;
        private Action _fixedLoop;
        
        public virtual void SetLoop(Action loop)
        {
            _loop = loop;
        }

        public virtual void SetFixedLoop(Action fixedLoop)
        {
            _fixedLoop = fixedLoop; 
        }

        protected virtual void Update()
        {
            _loop?.Invoke();
        }

        protected virtual void FixedUpdate()
        {
            _fixedLoop?.Invoke();
        }    
    }
}
