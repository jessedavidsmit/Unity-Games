using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesUpdate : MonoBehaviour {
	
	public Text livesText;

	// Use this for initialization
	void Start () {
		
		livesText.text = LivesManagerScript.remainingLives + " Remaining Lives";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
