using System.Collections;
using UnityEngine;

namespace GameLoopPattern
{
    [System.Serializable]
    public class GameLoopVariableTimeStep
    {
        public GameLoopVariableTimeStep ()
        {
        }
        
        public IEnumerator StartLoop ()
        {
            while (true)
            {
                Debug.Log ($"Variable time step GameLoop executed with {1 / Time.deltaTime} FPS");
                yield return new WaitForSeconds (Time.deltaTime);
            }
        }
    }
}
