using UnityEngine;

namespace SingletonPattern
{
	public class GameManager : MonoBehaviour
	{
		#region Private methods
    
		[ContextMenu("TestUnitySingleton")]
		private void TestUnitySingleton()
		{
			var instance = UnitySingleton.Instance;
			instance.TestSingleton();
			
			var instance2 = UnitySingleton.Instance;
			instance2.TestSingleton();
		}
		
		[ContextMenu("TestCSharpSingleton")]
		private void TestCSharpSingleton()
		{
			var instance = CSharpSingleton.Instance;
			instance.TestSingleton();
			
			var instance2 = CSharpSingleton.Instance;
			instance2.TestSingleton();
		}
		
		#endregion
	}
}
