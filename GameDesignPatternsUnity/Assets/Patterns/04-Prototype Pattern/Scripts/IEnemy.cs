using UnityEngine;

namespace PrototypePattern
{
    public interface IEnemy
    {
        public GameObject Clone();
    
        public string ToString();
    }
}