using UnityEngine;
using System.Collections;

public class EnemySpawnPoint : MonoBehaviour {

	private string wIcon = "wayIcon.png";
	private BattleManager bmInstance;
	public bool canSpawn = true;

	void OnDrawGizmos(){
		Gizmos.DrawIcon(transform.position, wIcon);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, 3f);
	}

	void Awake()
	{
		bmInstance = GameObject.Find("Managers").GetComponent<BattleManager>();
		if(canSpawn && BattleManager.enemyLeft > 0)
		{
			StartCoroutine(SpawnEnemy(bmInstance.enemy[0]));
		}
	}

	public IEnumerator SpawnEnemy(GameObject enemyType)
	{
		while(BattleManager.enemyLeft > 0)
		{
			Debug.Log("enemy spawned. Left: " + BattleManager.enemyLeft);
			canSpawn = false;
			BattleManager.enemyLeft --;
			GameObject enemyClone = Instantiate(enemyType, transform.position, Quaternion.identity) as GameObject;
			enemyClone.transform.LookAt(new Vector3(0,enemyClone.transform.position.y,0));
			enemyClone.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0.0f,1.0f),0,Random.Range(0.0f,1.0f)) * 50);

			yield return new WaitForSeconds(Random.Range(1,7));

			canSpawn = true;
		}
	}
}
