using UnityEngine;

namespace FlyweightPattern
{
	public class BugTester : MonoBehaviour
	{
		//Public Fields
		public BugBase bug;
	
		#region Public methods
    
		public void SetupBugBase(BugBase bug)
		{
			this.bug = bug;
		}
	
		#endregion
	}
}

