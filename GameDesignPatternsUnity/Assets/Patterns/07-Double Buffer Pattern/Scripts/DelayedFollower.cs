using System;
using DoubleBufferPattern;
using UnityEngine;

namespace DoubleBufferPattern
{
	public class DelayedFollower : MonoBehaviour
	{
		//Private Fields
		private Vector3 _lastFramePosition;
		private Quaternion _lastFrameRotation;
		//Public Fields
		public MovingObject movingObject;
	
		#region Unity methods

		private void Update()
		{
			transform.position= _lastFramePosition;
			transform.rotation= _lastFrameRotation;
		}

		private void LateUpdate()
		{
			_lastFramePosition = movingObject.transform.position;
			_lastFrameRotation = movingObject.transform.rotation;
		}

		#endregion
	
		#region Private methods
    
		#endregion
	
		#region Public methods
    
		#endregion
	}
}
