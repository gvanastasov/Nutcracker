using UnityEngine;
using System.Collections;

public class EnemySimpleAI : MonoBehaviour {
	
	void Awake ()
	{
		GetComponent<Rigidbody>().AddRelativeForce(transform.forward * Random.Range(0,100));	
	}
}
