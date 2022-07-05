using System;
using System.Collections.Generic;
using UnityEngine;
using UpdateMethod;

public class CentralUpdater : MonoBehaviour
{
	//Private Fields
	
	//Public Fields
	public List<ITickable> tickables = new List<ITickable>();

	#region Unity methods

	private void Start()
	{
		// Run this game at 1FPS
		Application.targetFrameRate = 1;
		tickables.Add(new FPSPrinter(1));
		tickables.Add(new TimePrinter());
	}

	private void Update()
	{
		if(tickables.Count == 0 ) return;
		Debug.Log("----Updating all tickables----");
		foreach (var tickable in tickables)
		{
			tickable.Tick();
		}
		Debug.Log("----End of updating all tickables----");
	}

	#endregion
}