using UnityEngine;
using System.Collections;

public class Parts : MonoBehaviour {

	
	void Update(){
		this.transform.position = GameObject.Find ("PlayerShip").transform.position;
	}
	
	public void RemovePart(){
		Destroy(gameObject);
	}
}
