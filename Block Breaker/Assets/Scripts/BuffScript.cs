using UnityEngine;
using System.Collections;

public class BuffScript : MonoBehaviour {

	private LevelManager levelManager;
	private Paddle paddle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D (Collider2D trigger)
	{
		//TODO
		/*if(trigger.gameObject.name == "wood-paddle")
		{
			print ("Trigger");
			levelManager = GameObject.FindObjectOfType<LevelManager>();
			levelManager.LoadLevel("GameOver");
		}*/
	}
	
}
