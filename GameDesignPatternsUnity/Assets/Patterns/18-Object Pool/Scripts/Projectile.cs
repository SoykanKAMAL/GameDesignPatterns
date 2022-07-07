using System;
using ObjectPoolPattern.ListApproach;
using UnityEngine;

namespace ObjectPoolPattern
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        //Private Fields
	    private float _bulletSpeed = 10f;
        private float _deathTime = 5f;
        private BulletPoolBase _bulletPool;
        
        private Rigidbody _rigidbody;
        private float _launchTime;
        //Public Fields
	
	
        #region Unity methods

        private void OnEnable()
        {
            _rigidbody = GetComponent<Rigidbody>();
            
            // Clear the velocity of the rigidbody
            _rigidbody.velocity = Vector3.zero;
            
            _rigidbody.AddForce(transform.forward * _bulletSpeed, ForceMode.VelocityChange);
            
            _launchTime = Time.time;
        }

        private void Update()
        {    
            //Deactivate the bullet
            if (Time.time - _launchTime > _deathTime)
            {
                _bulletPool.DeactivateBullet(this.gameObject);
            }
        }

        #endregion
        
        #region Public methods
        
        public void Initialize(BulletPoolBase bulletPool, float bulletSpeed = 10f, float deathTime = 5f)
        {
            _bulletPool = bulletPool;
            _bulletSpeed = bulletSpeed;
            _deathTime = deathTime;
        }
        
        #endregion
    }
}