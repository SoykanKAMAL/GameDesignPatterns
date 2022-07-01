using System;
using TMPro;
using UnityEngine;

public class BasicFpsCounter : MonoBehaviour
{
	//Public Fields
	public TextMeshProUGUI fpsText;
	
	#region Unity methods

	private void Update()
	{
		fpsText.text = $"FPS:\n{GetFps():0.00}";
	}

	#endregion
	
	#region Private methods
    
	private float GetFps()
	{
		// Find current FPS
		return 1 / Time.deltaTime;
	}
	
	#endregion
}