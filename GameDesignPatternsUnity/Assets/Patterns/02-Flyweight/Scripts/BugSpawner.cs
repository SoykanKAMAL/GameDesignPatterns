using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FlyweightPattern
{
	public class BugSpawner : MonoBehaviour
    {
    	//Private Fields
    	private Data flyWeightData;
    	private List<BugBase> bugs = new List<BugBase>();
    	//Public Fields
    	public GameObject bugPrefab;
    	public Transform heavyBugParent;
    	public Transform flyweightBugParent;
    	public TMP_InputField bugCountInput;
    	
    	#region Private methods
    
    	private void Start()
    	{
    		flyWeightData = new Data();
    	}
    
    	private void SpawnFlyweightBug(int count)
    	{
    		for (int i = 0; i < count; i++)
    		{
    			// Create flyWeightBug script
    			var flyWeightBug = new FlyWeightBug(flyWeightData);
    			
    			CreateBugCopy(flyweightBugParent, flyWeightBug);
    		}
    	}
    	
    	private void SpawnHeavyBug(int count)
    	{
    		for (int i = 0; i < count; i++)
    		{
    			// Create heavyBug script
    			var heavyBug = new HeavyBug();
    			
    			CreateBugCopy(heavyBugParent, heavyBug);
    		}
    	}
    
    	private void CreateBugCopy(Transform parent, BugBase bugBase)
    	{
    		// Instantiate a capsule
    		var bug = Instantiate(bugPrefab, 
    			new Vector3(Random.Range(-20f, 20f), 1, Random.Range(-20f, 20f)), 
    			Quaternion.identity,
    			parent);
    
    		// Add BugTester
    		var bugTesterScript = bug.AddComponent<BugTester>();
    			
    		// Assign BugBase script
    		bugTesterScript.SetupBugBase(bugBase);
    		
    		bugs.Add(bugBase);
    	}
    
    	#endregion
    	
    	#region Public methods
        
    	public void DestroyAllBugs()
    	{
    		// Destroy all children of heavyBugParent
    		foreach (Transform child in heavyBugParent)
    		{
    			Destroy(child.gameObject);
    		}
    		
    		// Destroy all children of flyweightBugParent
    		foreach (Transform child in flyweightBugParent)
    		{
    			Destroy(child.gameObject);
    		}
    		
    		bugs.Clear();
    		
    		// Collect garbage
    		GC.Collect();
    	}
    
    	public void CreateFlyweightBugs()
    	{
    		SpawnFlyweightBug(Int32.Parse(bugCountInput.text));
    	}
    	
    	public void CreateHeavyBugs()
    	{
    		SpawnHeavyBug(Int32.Parse(bugCountInput.text));
    	}
    	
    	#endregion
    }
}
