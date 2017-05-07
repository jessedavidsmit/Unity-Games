using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {

	
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject Smoke;
	//Spawn new balls into the game
	
	public GameObject obj;
	

	private bool isBreakable; 
	private LevelManager levelManager;
	private int timesHit;
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//Keep track of breakable bricks
		if(isBreakable){
			breakableCount++;
			
		}
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
		
		}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		
		if(isBreakable){
			HandleHits();
		}
		
	
		/*TODO Spawn items for player
		ObjectSpawnPosition = this.transform.position;
		ObjectSpawnPosition.x = this.transform.position.x + 0.3f;
		Instantiate(obj,ObjectSpawnPosition,Quaternion.identity);*/
	}
	
	void HandleHits()
	{
		
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(timesHit>=maxHits)
		{
			AudioSource.PlayClipAtPoint(crack,transform.position,0.1f);
			
			PuffSmoke();
			Destroy(gameObject);
			//Keep track of breakable bricks
			breakableCount--;
		
			levelManager.BrickDestroyed();
		
		}
		else{
			LoadSprites();
		}
	}
	
	void PuffSmoke(){
		Vector3 smokeSpawnPos = transform.position;
		smokeSpawnPos.x = smokeSpawnPos.x + 0.3f;
		GameObject smokePuff = Instantiate(Smoke,smokeSpawnPos ,Quaternion.Euler(0,180f,0)) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
	}
	
	
	void LoadSprites()
	{
	 	int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex] != null){
	 		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	 	}
	 	else {
	 		Debug.LogError("Sprite missing for Brick script in hit Sprites.");
	 	}
	 	
		
	}
	
	//TODO Remove this method once we can actually win
	
	void SimulateWin()
	{
		
		levelManager.LoadNextLevel();
	}
	
}
