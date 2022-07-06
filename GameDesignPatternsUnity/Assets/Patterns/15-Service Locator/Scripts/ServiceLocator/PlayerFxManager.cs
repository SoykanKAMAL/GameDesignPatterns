using UnityEngine;

namespace ServiceLocator
{
    public class PlayerFxManager : FxManager
    {
        public override void PlayFx(Vector3 position, int fxId)
        {
            Debug.Log($"PlayFx {fxId} at {position}");
        }

        public override void StopFx(int fxId)
        {
            Debug.Log($"StopFx {fxId}");
        }

        public override void StopAllFx()
        {
            Debug.Log("StopAllFx");
        }
    }
}