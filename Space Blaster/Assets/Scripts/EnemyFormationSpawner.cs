using UnityEngine;
using System.Collections;

public class EnemyFormationSpawner : MonoBehaviour {

	public int BossScore = 1000;
	public GameObject bossPrefab;
	public float speed = 5f;
	
	private bool movingRight = true;
	private bool movingLeft = true;
			
	public static bool bossSummoned = false;
	float xmin;
	float xmax;
	GameObject enemyFormation;
	bool wave1 = false;
	bool wave2 = false;
	bool wave3 = false;
	bool wave4 = false;
	bool wave5 = false;
	bool wave6 = false;
	bool wave7 = false;
	bool wave8 = false;
	
	
	
			
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));	
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		
		xmin =  leftmost.x;
		xmax = rightmost.x;
		
		enemyFormation = GameObject.Find("EnemyFormation");
	}
	
	// Update is called once per frame
	void Update () {
		EnemyMovement();
	
		if(Score.score >= 500 && wave1 == false){
			SummonEnemyFormation();
			wave1 = true;
		}
		if(Score.score >= 2000 && wave2 == false){
			SummonEnemyFormation();
			wave2 = true;
		}
		if(Score.score >= 4000 && wave3 == false){
			SummonEnemyFormation();
			wave3 = true;
		}
		if(Score.score >= 6000 && wave4 == false){
			SummonEnemyFormation();
			wave4 = true;
		}
		if(Score.score >= 8000 && wave5 == false){
			SummonEnemyFormation();
			wave5 = true;
		}
		if(Score.score >= 10000 && wave6 == false){
			SummonEnemyFormation();
			wave6 = true;
		}
		if(Score.score >= 12000 && wave7 == false){
			SummonEnemyFormation();
			wave7 = true;
		}
		if(Score.score >= 14000 && wave8 == false){
			SummonEnemyFormation();
			wave8 = true;
		}
		
		
		
		
		if (Score.score >= BossScore && !bossSummoned){
			SummonBoss();
			Object.Destroy(GameObject.Find("EnemyFormation"));
			Object.Destroy(GameObject.Find("EnemyFormation(Clone)"));					
		}
	
	}
	
	void SummonEnemyFormation(){
		Vector3 newEnemyPos = new Vector3(Random.Range(-5f,5f),Random.Range(-1f,2f),transform.position.z);
		try{
		Instantiate(enemyFormation,newEnemyPos,Quaternion.identity) ; }
		catch(MissingReferenceException e)
		{
			Debug.Log("Game object not found:" + e.Message);
		}
	}
	
	void SummonBoss()
	{
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));	
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		Vector3 bossPos = new Vector3(-1 * (leftmost.x) - rightmost.x,2,leftmost.z);
		GameObject enemyBoss = Instantiate(bossPrefab,bossPos,Quaternion.identity) as GameObject; 
		enemyBoss.transform.parent = transform;
		bossSummoned = true;
	}
	
	void EnemyMovement(){
		if(movingRight){
			transform.position += new Vector3(speed*Time.deltaTime ,0 );
		}
		else if (movingLeft){
			transform.position += new Vector3(-speed*Time.deltaTime ,0 );
		}
		
		float rightEdgeOfFormation = transform.position.x ;
		float leftEdgeOfFormation = transform.position.x ;
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
