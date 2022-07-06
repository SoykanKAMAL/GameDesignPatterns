using UnityEngine;

namespace ServiceLocator
{
    public abstract class FxManager
    {
        public abstract void PlayFx(Vector3 position, int fxId);
        
        public abstract void StopFx(int fxId);
        
        public abstract void StopAllFx();
    }
}