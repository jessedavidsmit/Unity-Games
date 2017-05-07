using UnityEngine;
using System.Collections;

public class LooseShredder : MonoBehaviour {

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	
	
	void OnTriggerEnter2D(Collider2D col){	
		Destroy(col.gameObject);
		levelManager.LoadLevel("03 Lose");	
	}
}
