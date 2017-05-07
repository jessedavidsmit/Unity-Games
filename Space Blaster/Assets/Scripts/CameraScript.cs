using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public void OnDrawGizmos(){
	
		
		Camera cam = Camera.main;
		float height = 2f * cam.orthographicSize;
		float width = height * cam.aspect;
	
		Gizmos.DrawWireCube(transform.position,new Vector3(width,height));
	}
}
