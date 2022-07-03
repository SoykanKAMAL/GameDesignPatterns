
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
	//Private Fields
	
	//Public Fields
	public GameObject devilPrefab;
	public GameObject giantPrefab;
	public List<Spawner> spawners = new List<Spawner>();
	public float spawnTimer = 2f;
	public TextMeshProUGUI giantCounterText;
	public TextMeshProUGUI devilCounterText;
	
	#region Private methods

	private void CreateSpawner(IEnemy enemy)
	{
		var spawner = new Spawner(enemy, spawnTimer);
		spawners.Add(spawner);
		StartCoroutine(SpawnLoop(spawner));
	}

	private IEnumerator SpawnLoop(Spawner spawner)
	{
		if(spawner.SpawnTime == 0) yield break;
		while (true)
		{
			giantCounterText.text = $"Current count: {Giant.GiantCount.ToString()}";
			devilCounterText.text = $"Current count: {Devil.DevilCount.ToString()}";
			var spawnedObject = spawner.Spawn();
			spawnedObject.transform.position = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
			spawnedObject.transform.position += spawnedObject.transform.localScale.y * Vector3.up;
			yield return new WaitForSeconds(spawnTimer);
		}
	}

	#endregion
	
	#region Public methods
	
	[ContextMenu("CreateDemonSpawner")]
	public void CreateDevilSpawner()
	{
		CreateSpawner(new Devil(devilPrefab));
	}
	
	[ContextMenu("CreateGiantSpawner")]
	public void CreateGiantSpawner()
	{
		CreateSpawner(new Giant(giantPrefab));
	}

	#endregion
}