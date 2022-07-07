using UnityEngine;

namespace ObjectPoolPattern
{
    public abstract class BulletPoolBase
    {
        protected int _currentProjectileCount = 0;
        protected Transform _bulletContainer;
        protected GameObject _bulletPrefab;
        
        public BulletPoolBase(GameObject bulletPrefab, Transform bulletContainer)
        {
            _bulletPrefab = bulletPrefab;
            _bulletContainer = bulletContainer;
        }
        public abstract GameObject GetBullet();

        public abstract GameObject GenerateBullet();
        
        public abstract void DeactivateBullet(GameObject bullet);

        protected abstract void AddProjectileComponent(GameObject bulletGo);
    }
}