using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour {

	public float health = 300f;
	public GameObject ProjectilePrefab;
	public float projectileSpeed = 5f;
	public float shootFrequency = 0.5f;
	public int scoreValue = 100;
	public AudioClip fireSound;
	public AudioClip deathSound;
	public GameObject explosion;
	public GameObject[] buffs = new GameObject[5];
	
	public float buffSpawnRate = 25f;
	
	private static float buffTime = 0.0f;
   
   void Start(){
   		if(Difficulty.difficulty == "Normal"){
   			Debug.Log ("Setting Difficulty to normal");
   		}
		if(Difficulty.difficulty == "Easy"){
			Debug.Log ("Setting Difficulty to easy");
			projectileSpeed = 4f;
			shootFrequency = 0.15f;
			buffSpawnRate = 10f;
		}
		if(Difficulty.difficulty == "Hard"){
			Debug.Log ("Setting Difficulty to hard");
			projectileSpeed = 6f;
			shootFrequency = 0.35f;
		}
   }
	
	void OnTriggerEnter2D(Collider2D col){
		Projectile missle = col.gameObject.GetComponent<Projectile>();
		if(missle){
			health -= missle.GetDamage();
			missle.Hit();
			if(health <= 0){
				Destroy(gameObject);
				Score.ScoreKeep(scoreValue);
				AudioSource.PlayClipAtPoint(deathSound,Camera.main.transform.position);
				Explosions();
				
				if(this.tag == "Boss")
				{
					LevelManager levelMan = GameObject.Find("Level Manager").GetComponent<LevelManager>();
					levelMan.LoadLevel("Win");
				}
				if(Time.time > buffTime){
					SpawnBuff();				
				}
			}
		}
	}
	
	void Explosions(){
		
		GameObject explo = Instantiate(explosion,transform.position,Quaternion.identity) as GameObject;
		Destroy(explo,2f);
		
	}
	
	void SpawnBuff(){
		buffTime = buffSpawnRate + Time.time;
		buffTime += Random.Range(-10,10);//Give buff drops a little randomness
		GameObject buff = Instantiate(buffs[Random.Range(0,4)],transform.position, Quaternion.identity) as GameObject;
		buff.GetComponent<Rigidbody2D>().velocity = new Vector3(0f,-1.5f,0f);
	}
	
	
	void Update(){
		float probability = Time.deltaTime * shootFrequency;
		if(Random.value < probability){
			Fire();
		}
		
	}
	
	void Fire(){
		
		
		GameObject Enemyprojectile = Instantiate(ProjectilePrefab,transform.position + new Vector3(0,-0.1f,0),transform.rotation) as GameObject;
		if(ProjectilePrefab.tag == "SpecialProjectile"){
			Vector3 direction = ( GameObject.Find ("PlayerShip").transform.position - Enemyprojectile.transform.position ).normalized;
			
			Enemyprojectile.rigidbody2D.velocity = direction * projectileSpeed;
		}
		else 
		{Enemyprojectile.rigidbody2D.velocity =  new Vector3(0,-projectileSpeed,0);}
			AudioSource.PlayClipAtPoint(fireSound,Camera.main.transform.position);
	}
}
