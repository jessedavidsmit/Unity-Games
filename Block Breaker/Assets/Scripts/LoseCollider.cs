using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	private BallScript ball;
	private LivesManagerScript liveManager;
	
	public static int currentLevel;
	
	void OnTriggerEnter2D (Collider2D trigger)
	{
		//ball = GameObject.FindObjectOfType<BallScript>();
		//bool isMainBall = (ball.tag == "MainBall");
		
		if(trigger.gameObject.name == "GameBall")
		{	
			
			LivesManagerScript.remainingLives-- ;
			levelManager = GameObject.FindObjectOfType<LevelManager>();
			liveManager = GameObject.FindObjectOfType<LivesManagerScript>();
			if(LivesManagerScript.remainingLives < 0)
			{
				
				liveManager.ResetLives();
				//Trigger GameOver Screen
			 	levelManager.LoadLevel("GameOver");
			 	
		 	}
		 	else{
		 		currentLevel = Application.loadedLevel;
				levelManager.LoadLevel("Retry");	
		 	}
	 	}
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		print ("Collision");
		
	}
	
}
