using System.Collections;
using UnityEngine;

namespace GameLoopPattern
{
    [System.Serializable]
    public class GameLoopFixedTimeStep
    {
        public GameLoopFixedTimeStep ()
        {
        }
        
        public IEnumerator StartLoop ()
        {
            while (true)
            {
                Debug.Log ($"Fixed time step GameLoop executed with {1 / Time.fixedDeltaTime} FPS");
                yield return new WaitForSeconds (Time.fixedDeltaTime);
            }
        }
    }
}
