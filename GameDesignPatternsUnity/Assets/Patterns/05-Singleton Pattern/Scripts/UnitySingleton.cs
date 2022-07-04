using System;
using UnityEngine;

namespace SingletonPattern
{
	public class UnitySingleton : MonoBehaviour
	{
		//Private Fields
		private static UnitySingleton _instance = null;

		private int _randomNumber;
		//Public Fields
		public static UnitySingleton Instance
		{
			get
			{
				if (_instance != null) return _instance;
				// Find the object in the scene that has the component.
				_instance = FindObjectOfType<UnitySingleton>();
				if (_instance != null) return _instance;
				// Create a new GameObject and add the Singleton component to it.
				var obj = new GameObject
				{
					name = "UnitySingleton"
				};
				_instance = obj.AddComponent<UnitySingleton>();
				_instance.Init();
						
				// The singleton object should be persistent between scenes.
				DontDestroyOnLoad(obj);
				return _instance;
			}
		}
	
		#region Unity methods

		private void Awake()
		{
			if(_instance == null)
			{
				_instance = this;
				_instance.Init();
			}
			else
			{
				DestroyImmediate(gameObject);
			}
			
			DontDestroyOnLoad(gameObject);
		}

		#endregion

		#region Private methods

		private void Init()
		{
			_randomNumber = UnityEngine.Random.Range(0, 100);
		}

		#endregion
	
		#region Public methods
    
		public void TestSingleton()
		{
			Debug.Log($"Random number: {_randomNumber}");
		}
		
		#endregion
	}
}
