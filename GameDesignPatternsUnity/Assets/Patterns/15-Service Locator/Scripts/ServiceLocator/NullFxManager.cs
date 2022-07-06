using UnityEngine;

namespace ServiceLocator
{
    public class NullFxManager : FxManager
    {
        public override void PlayFx(Vector3 position, int fxId)
        {
            Debug.Log("NullFxManager.PlayFx");
        }

        public override void StopFx(int fxId)
        {
            Debug.Log("NullFxManager.StopFx");
        }

        public override void StopAllFx()
        {
            Debug.Log("NullFxManager.StopAllFx");
        }
    }
}