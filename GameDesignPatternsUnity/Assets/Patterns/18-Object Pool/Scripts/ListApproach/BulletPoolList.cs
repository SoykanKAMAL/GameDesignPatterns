using System.Collections.Generic;
using UnityEngine;

namespace ObjectPoolPattern.ListApproach
{
    public class BulletPoolList : BulletPoolBase
    {
        private List<GameObject> _bulletList;
        
        public BulletPoolList(GameObject bulletPrefab, Transform bulletContainer) : base(bulletPrefab, bulletContainer)
        {
            _bulletList = new List<GameObject>();
        }

        public override GameObject GetBullet()
        {
            var bullet = FindFirstInactiveGameObject()?? GenerateBullet();
            
            bullet.SetActive(true);
            
            Debug.Log($"GetBullet from List approach, Current bullet count: {_bulletList.Count}");
            return bullet;
        }
        
        private GameObject FindFirstInactiveGameObject()
        {
            return _bulletList.Find(b => !b.activeSelf);
        }

        public override GameObject GenerateBullet()
        {
            var newBullet = Object.Instantiate(_bulletPrefab, _bulletContainer);
            AddProjectileComponent(newBullet);
            _currentProjectileCount++;
            _bulletList.Add(newBullet);
            return newBullet;
        }

        public override void DeactivateBullet(GameObject bullet)
        {
            bullet.SetActive(false);
        }

        protected override void AddProjectileComponent(GameObject bulletGo)
        {
            bulletGo.AddComponent<Projectile>().Initialize(this);
        }
    }
}