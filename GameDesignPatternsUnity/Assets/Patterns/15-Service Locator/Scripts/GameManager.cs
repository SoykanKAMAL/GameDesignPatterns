using System;
using UnityEngine;

namespace ServiceLocator
{
    public class GameManager : MonoBehaviour
    {
        #region Unity methods

        private void Start()
        {
            var playerFxManager = new PlayerFxManager();
            
            Locator.Provide(playerFxManager);
        }

        private void Update()
        {
            var playerFxManager = Locator.GetFxManager();
            
            playerFxManager.PlayFx(position: Vector3.zero, fxId: 0);
        }

        #endregion
    }
}