using UnityEngine;

namespace PrototypePattern
{
    [System.Serializable]
    public class Spawner
    {
        public IEnemy Prototype { get; }
        public float SpawnTime { get; }
    
        public Spawner(IEnemy prototype, float spawnTime)
        {
            Prototype = prototype;
            SpawnTime = spawnTime;
        }
    
        public GameObject Spawn()
        {
            return Prototype.Clone();
        }
    }
}
