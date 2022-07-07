using System;
using ObjectPoolPattern.ListApproach;
using ObjectPoolPattern.QueueApproach;
using UnityEngine;

namespace ObjectPoolPattern
{
    public class Gun : MonoBehaviour
    {
        //Private Fields
		private BulletPoolQueue _bulletPoolQueue;
		private BulletPoolList _bulletPoolList;
        //Public Fields
		public GameObject bullet;

		#region Unity methods

		private void Start()
		{
			_bulletPoolQueue = new BulletPoolQueue(bullet, this.transform);
			_bulletPoolList = new BulletPoolList(bullet, this.transform);
		}

		private void Update()
        {
	        if(Input.GetMouseButtonDown(0))
	        {
		        var bullet = _bulletPoolQueue.GetBullet();
		        bullet.transform.position = this.transform.position;
		        bullet.transform.rotation = this.transform.rotation;
	        }
	        
	        if(Input.GetMouseButtonDown(1))
	        {
		        var bullet = _bulletPoolList.GetBullet();
		        bullet.transform.position = this.transform.position;
		        bullet.transform.rotation = this.transform.rotation;
	        }
        }

        #endregion
	
        #region Private methods
    
        #endregion
	
        #region Public methods
    
        #endregion
    }
}