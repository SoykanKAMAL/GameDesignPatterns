using UnityEngine;

namespace GameLoopPattern
{
	[RequireComponent(typeof(Rigidbody))]
	public class LagObject : MonoBehaviour
	{
		private Rigidbody _rigidbody => GetComponent<Rigidbody>();
		#region Unity methods
    
		// Random movement
		private void Update()
		{
			_rigidbody.AddForce(new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f)) * Time.deltaTime, ForceMode.Impulse);
		}

		#endregion
	}
}
