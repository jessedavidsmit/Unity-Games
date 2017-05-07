using UnityEngine;
using System.Collections;

public class DamagedShip : MonoBehaviour {

	
	void Update(){
		this.transform.position = GameObject.Find ("PlayerShip").transform.position;
	}
	
}
