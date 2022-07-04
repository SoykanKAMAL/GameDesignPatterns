using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLoopPattern
{
    [System.Serializable]
    public class WhileLoop
    {
        public WhileLoop ()
        {
		
        }
        
        public IEnumerator StartLoop ()
        {
            while (true)
            {
                Debug.Log ($"Whileloop executed with 30 FPS");
                yield return new WaitForSeconds (1/30f);
            }
        }
    }
}
