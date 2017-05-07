using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject enemyPrefab;
	public GameObject enemyPrefab1;
	public GameObject enemyPrefab2;
	public GameObject enemyPrefab3;
	public GameObject enemyPrefab4;
	public GameObject enemyPrefab5;
	public GameObject enemyPrefab6;
	public GameObject enemyPrefab7;
	
	GameObject[] go = new GameObject[10];
	
	
	
	public float GizmoWidht = 10f;
	public float GizmoHeight = 5f;
	public float speed = 5f;
	public float spawnDelay = 1f;
	

	
	private bool movingRight = true;
	private bool movingLeft = true;
	
	
	float xmin;
	float xmax;
	
	
	void FillEnemyArray(){
		go[0] = enemyPrefab;
		go[1] = enemyPrefab1;
		go[2] = enemyPrefab2;
		go[3] = enemyPrefab3;
		go[4] = enemyPrefab4;
		go[5] = enemyPrefab5;
		go[6] = enemyPrefab6;
		go[7] = enemyPrefab7;
		//go[0] = enemyPrefab;
	}

	// Use this for initialization
	void Start () {
		FillEnemyArray();
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));	
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		
		xmin =  leftmost.x;
		xmax = rightmost.x;
		SpawnUntillFull();
	}
	
	
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position,new Vector3(GizmoWidht,GizmoHeight));
	}
	
	// Update is called once per frame
	void Update () {
		EnemyMovement();
		if(AllMembersDead()){
			Debug.Log("Empty Formation");
			
			SpawnUntillFull();			
		}
		
	}
		
	
	
	
	Transform NextFreePosition(){
		foreach(Transform child in transform){
			if(child.childCount == 0){
				return child;
			}
		}
		return null;
	}
	
	bool AllMembersDead(){
		foreach(Transform child in transform){
			if(child.childCount > 0){
				return false;
			}
		}
		return true;
	}
	
	void SpawnUntillFull(){
		Transform freePos = NextFreePosition();
		if(freePos){
			GameObject enemy = Instantiate(go[Random.Range(0,7)],freePos.position,Quaternion.identity) as GameObject;
			enemy.transform.parent = freePos;}
		if(NextFreePosition()){
			Invoke ("SpawnUntillFull",spawnDelay);
		}
	}
	
	
	void EnemyMovement(){
		if(movingRight){
			transform.position += new Vector3(speed*Time.deltaTime ,0 );
		}
		else if (movingLeft){
			transform.position += new Vector3(-speed*Time.deltaTime ,0 );
		}
		
		float rightEdgeOfFormation = transform.position.x + (0.5f*GizmoWidht);
		float leftEdgeOfFormation = transform.position.x - (0.5f*GizmoWidht);
		if (leftEdgeOfFormation < xmin ){
			movingRight = true;	
			movingLeft = false;
		}
		else if (rightEdgeOfFormation > xmax){
			movingRight = false;	
			movingLeft = true;
		}
	}
	
}
