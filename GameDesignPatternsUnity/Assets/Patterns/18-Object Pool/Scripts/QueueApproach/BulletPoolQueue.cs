using System.Collections.Generic;
using UnityEngine;

namespace ObjectPoolPattern.QueueApproach
{
    public class BulletPoolQueue : BulletPoolBase
    {
        
        private Queue<GameObject> _bulletQueue;
        
        public BulletPoolQueue(GameObject bulletPrefab, Transform bulletContainer) : base(bulletPrefab, bulletContainer)
        {
            _bulletQueue = new Queue<GameObject>();
        }
        
        public override GameObject GetBullet()
        {
            GameObject bulletGo;
            if (_bulletQueue.Count > 0)
            {
                bulletGo = _bulletQueue.Dequeue();
                bulletGo.SetActive(true);
            }
            else
            {
                bulletGo = GenerateBullet();
            }
            Debug.Log("BulletPoolQueue: GetBullet(), Current Projectile Count: " + _currentProjectileCount);
            return bulletGo;
        }

        public override GameObject GenerateBullet()
        {
            var newBullet = Object.Instantiate(_bulletPrefab, _bulletContainer);
            AddProjectileComponent(newBullet);
            _currentProjectileCount++;
            return newBullet;
        }
        
        protected override void AddProjectileComponent(GameObject bulletGo)
        {
            bulletGo.AddComponent<Projectile>().Initialize(this);
        }

        public override void DeactivateBullet(GameObject bullet)
        {
	        bullet.SetActive(false);
            _bulletQueue.Enqueue(bullet);
        }
    }
}