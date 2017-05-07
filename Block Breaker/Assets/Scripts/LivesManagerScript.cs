using UnityEngine;
using System.Collections;

public class LivesManagerScript : MonoBehaviour {

	public static int remainingLives = 4;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ResetLives(){
		Debug.Log("Lives Reset");
		remainingLives = 4;
	}
}
