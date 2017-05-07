using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float ShipSpeed; 
	public float padding = 1f;
	public GameObject ProjectilePrefab;
	public float projectileSpeed;
	public float fireRate = 0.2f;
	public float health = 300f;
	public AudioClip fireSound;
	public AudioClip lostLifeSound;
	public AudioClip deathSound;
	public AudioClip buffCollectSound;
	public AudioClip debuffCollectSound;
	public GameObject explosion;
	public GameObject[] shields = new GameObject[3];
	public GameObject[] shipDamage = new GameObject[3];
	public GameObject[] parts = new GameObject[3];
	
	string[] lives = new string[6];
	
	float xmin;
	float xmax;
	int increment = 0;
	
	public static bool shieldActive = false;
	private float nextFire = 0.0f;
	private float tempFireRate = 0.2f;
	private bool doubleFire = false;
	private bool quadFire = false;
	bool shipDam1 = false;
	bool shipDam2 = false;
	bool shipDam3 = false;
	GameObject shipD1;
	GameObject shipD2;
	GameObject shipD3;
	GameObject PartGun1;
	GameObject PartGun2;
	
	
	void OnTriggerEnter2D(Collider2D col){
		EnemyProjectile missle = col.gameObject.GetComponent<EnemyProjectile>();
		if(missle){
			health -= missle.GetDamage();
			missle.Hit();
			
			Destroy(GameObject.Find(lives[increment]));
			
			increment++;
			ShipDamage();
			if(increment < lives.Length){AudioSource.PlayClipAtPoint(lostLifeSound,Camera.main.transform.position);}
			if(health <= 0){
				PlayerDeath();
				
			}
		}
		Buffs(col);
	
	}
	
	void ShipDamage(){
		
		if(shipDam1 == false && health <= 250f ){
			shipD1 = Instantiate(shipDamage[0],transform.position,Quaternion.identity) as GameObject;
			shipDam1 = true;}
		
		if(shipDam2 == false && health <= 150f){
			Destroy(shipD1);
			shipD2 = Instantiate(shipDamage[1],transform.position,Quaternion.identity) as GameObject;
			shipDam2 = true;}
		
		if(shipDam3 == false && health <= 50f){
			Destroy(shipD2);
			shipD3 = Instantiate(shipDamage[2],transform.position,Quaternion.identity) as GameObject;
			shipDam3 = true;}
			
	}
	
	void Buffs(Collider2D col){
		if(col.tag == "pill_blue"){	    
			BuffCollected(col);
			
			
			if(IsInvoking("Fire")){
				CancelInvoke("Fire");
				InvokeRepeating("Fire",0.000001f,tempFireRate);}
			StartCoroutine(ResetFireRateIE());
		}
		if(col.tag == "powerupBlue_shield"){
			//if(shieldActive == false){
				shieldActive = true;	    
				BuffCollected(col);
				Instantiate(shields[0],transform.position,Quaternion.identity);
			//}
			
		}
		if(col.tag == "bold_silver"){
			BuffCollected(col);
			doubleFire = true;
			StartCoroutine(ResetFireRateDoubleIE());	
		}
		if(col.tag == "bolt_gold"){
			BuffCollected(col);
			quadFire = true;
			
			StartCoroutine(ResetFireRateQuadIE());
			
		}
		
	}
	
	IEnumerator ResetFireRateIE(){
		yield return new WaitForSeconds(6f);
		if(IsInvoking("Fire")){
			CancelInvoke("Fire");
			InvokeRepeating("Fire",0.000001f,fireRate);}
	}
	IEnumerator ResetFireRateDoubleIE(){
		yield return new WaitForSeconds(6f);
		doubleFire = false;

	}
	IEnumerator ResetFireRateQuadIE(){
		yield return new WaitForSeconds(6f);
		quadFire = false;
		
	}
	
	void BuffCollected(Collider2D col){
		Buff buff = col.gameObject.GetComponent<Buff>();
		AudioSource.PlayClipAtPoint(buffCollectSound,Camera.main.transform.position);
		buff.Hit();
		
	}
	
	
	void PlayerDeath(){
		AudioSource.PlayClipAtPoint(deathSound,Camera.main.transform.position);
		LevelManager levelMan = GameObject.Find("Level Manager").GetComponent<LevelManager>();
		levelMan.LoadLevel("GameOver");
		GameObject explo = Instantiate(explosion,transform.position,Quaternion.identity) as GameObject;
		GameObject explo2 = Instantiate(explosion,transform.position + new Vector3(-0.5f,0,0),Quaternion.identity) as GameObject;
		GameObject explo3 = Instantiate(explosion,transform.position + new Vector3(0.5f,0,0),Quaternion.identity) as GameObject;
		Destroy(explo,2f);
		Destroy(explo2,2f);
		Destroy(explo3,2f);
		Destroy(gameObject);
		Destroy(shipD3);
	}
	
	void Lives(){
		lives[0] = "Live1";
		lives[1] = "Live2";
		lives[2] = "Live3";
		lives[3] = "Live4";
		lives[4] = "Live5";
		lives[5] = "Live6";
	}
	
	
	
	// Use this for initialization
	void Start () {
		Lives();
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin =  leftmost.x + padding;
		xmax = rightmost.x - padding;
		
		
	}
	
	void Fire(){
		if(doubleFire ==  false && quadFire == false){
			GameObject projectile = Instantiate(ProjectilePrefab,transform.position + new Vector3(0,0.1f,0),Quaternion.identity) as GameObject;
			projectile.rigidbody2D.velocity =  new Vector3(0,projectileSpeed,0);
			AudioSource.PlayClipAtPoint(fireSound,Camera.main.transform.position);
			Debug.Log("Shot fired");
		}
		if(doubleFire ==  true){
			GameObject projectile = Instantiate(ProjectilePrefab,transform.position + new Vector3(-0.5f,0.1f,0),Quaternion.identity) as GameObject;
			projectile.rigidbody2D.velocity =  new Vector3(0,projectileSpeed,0);
			AudioSource.PlayClipAtPoint(fireSound,Camera.main.transform.position);
			
			GameObject projectile2 = Instantiate(ProjectilePrefab,transform.position + new Vector3(0.5f,0.1f,0),Quaternion.identity) as GameObject;
			projectile2.rigidbody2D.velocity =  new Vector3(0,projectileSpeed,0);
			AudioSource.PlayClipAtPoint(fireSound,Camera.main.transform.position);
			Debug.Log("Shot fired");
		}
		if(quadFire ==  true ){
			GameObject projectile = Instantiate(ProjectilePrefab,transform.position + new Vector3(-0.5f,0.1f,0),Quaternion.identity) as GameObject;
			projectile.rigidbody2D.velocity =  new Vector3(0,projectileSpeed,0);
			AudioSource.PlayClipAtPoint(fireSound,Camera.main.transform.position);
			
			GameObject projectile2 = Instantiate(ProjectilePrefab,transform.position + new Vector3(0.5f,0.1f,0),Quaternion.identity) as GameObject;
			projectile2.rigidbody2D.velocity =  new Vector3(0,projectileSpeed,0);
			AudioSource.PlayClipAtPoint(fireSound,Camera.main.transform.position);
			Debug.Log("Shot fired");
			
			GameObject projectile3 = Instantiate(ProjectilePrefab,transform.position + new Vector3(-1f,0.1f,0),Quaternion.identity) as GameObject;
			projectile3.rigidbody2D.velocity =  new Vector3(0,projectileSpeed,0);
			AudioSource.PlayClipAtPoint(fireSound,Camera.main.transform.position);
			
			GameObject projectile4 = Instantiate(ProjectilePrefab,transform.position + new Vector3(1f,0.1f,0),Quaternion.identity) as GameObject;
			projectile4.rigidbody2D.velocity =  new Vector3(0,projectileSpeed,0);
			AudioSource.PlayClipAtPoint(fireSound,Camera.main.transform.position);
			Debug.Log("Shot fired");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMovement();
		
				
		if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire ){
			nextFire =  Time.time + fireRate;
			InvokeRepeating("Fire",0.000001f,fireRate);
			Debug.Log("Shoot");	
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
			
		}
		
	}
	
	void PlayerMovement(){
		if(Input.GetKey(KeyCode.RightArrow)){	
			transform.position += Vector3.right * ShipSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left * ShipSpeed * Time.deltaTime;
		}
		
		//restricting the player to the game space
		float newX = Mathf.Clamp(transform.position.x, xmin,xmax );
		transform.position = new Vector3(newX,transform.position.y,transform.position.z);
	}
}
