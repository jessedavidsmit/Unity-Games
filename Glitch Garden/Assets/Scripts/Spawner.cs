using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackers;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject thisAttacker in attackers){
			if(isTimetoSpawn(thisAttacker)){
				Spawn (thisAttacker);
			}
		}
	}
	
	bool isTimetoSpawn(GameObject attackerGameObject){
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();
		
		float meansSpawnDelay = attacker.seenEverySeconds;
		float spawnPerSecond = 1 / meansSpawnDelay;
		
		if(Time.deltaTime > meansSpawnDelay){
			Debug.LogWarning("Spawn rate capped by frame rate");
		}
		
		float treshold = spawnPerSecond * Time.deltaTime / 5;
		
		return (Random.value < treshold);
	}
	
	void Spawn(GameObject obj){
		GameObject myAttacker = Instantiate(obj,this.transform.position,Quaternion.identity) as GameObject;
		myAttacker.transform.parent = this.transform;
	}
}
