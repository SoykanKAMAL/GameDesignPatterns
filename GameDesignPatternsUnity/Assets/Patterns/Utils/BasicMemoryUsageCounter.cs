using System;
using TMPro;
using UnityEngine;
using UnityEngine.Profiling;

public class BasicMemoryUsageCounter : MonoBehaviour
{
	//Public Fields
	public TextMeshProUGUI memoryUsageText;
	
	#region Unity methods

	private void Update()
	{
		memoryUsageText.text = $"Memory Usage:\n{GetMemoryUsage():0.00}MB";
	}

	#endregion
	
	#region Private methods
    
	private float GetMemoryUsage()
	{
		// Find current Memory Usage
		return GC.GetTotalMemory(false) / 1024f / 1024f;
	}
	
	#endregion
}