using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {

	private static BattleManager instanceRef;
	public static List<EnemySpawnPoint> spawnPointsAll = new List<EnemySpawnPoint>();
	public static List<EnemySpawnPoint> spawnPointsFree = new List<EnemySpawnPoint>();

	// TO DO: to be managed more deeper, based on level design later in the process
	public int enemyCount;
	public static int enemyLeft = 50;
	private int enemyLeftToSpawn;
	//TO DO: create a database for enemyTypes, rather than using public accessable variables
	public GameObject[] enemy;
	
	void Awake () {

		if (instanceRef == null) {
			instanceRef = this;
			DontDestroyOnLoad (gameObject);
		} else {
			DestroyImmediate (gameObject);
		}

		// Find all spawn positions
		Transform sC = GameObject.FindGameObjectWithTag("SpawnContainer").transform;
		for(int i=0; i <  sC.childCount; i++)
		{
			spawnPointsAll.Add(sC.GetChild(i).GetComponent<EnemySpawnPoint>());
		}

	}

	void Start()
	{
		/*Debug.Log(spawnPointsFree.Count);
		for(int j=0; j < enemyCount; j++)
		{
			if(spawnPointsFree.Count > 0)
			{
				int randomSP = Random.Range(0,spawnPointsFree.Count);
				StartCoroutine(spawnPointsFree[randomSP].SpawnEnemy(enemy[0]));
			} else {
				enemyLeftToSpawn++;
			}
		}*/
	}

	void Update()
	{
		/*if(spawnPointsFree.Count > 0 && enemyLeftToSpawn != 0)
		{
			Debug.Log("spawn more");
		}*/
	}

	private void SpawnEnemies()
	{

	}
}
