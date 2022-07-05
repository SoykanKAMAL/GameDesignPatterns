using DG.Tweening;
using UnityEngine;

namespace DoubleBufferPattern
{
	public class MovingObject : MonoBehaviour
	{
		//Private Fields
	
		//Public Fields
	
	
		#region Unity methods
    
		void Start()
		{
			// Run game at 30fps
			Application.targetFrameRate = 30;
			transform.DOMoveX(transform.position.x + 20, 2).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
			transform.DORotate(new Vector3(0, -359, 0), 2).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
			transform.DORotate(new Vector3(180, 0, 0), 8).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
		}
    
		#endregion
	
		#region Private methods
    
		#endregion
	
		#region Public methods
    
		#endregion
	}
}
