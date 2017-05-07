using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	
	private GameObject defenderParent;
	private StarDisplay starDisplay;
	

	// Use this for initialization
	void Start () {
		defenderParent =  GameObject.Find("Defenders");
		starDisplay = FindObjectOfType<StarDisplay>();
		
		
		if(!defenderParent){
			defenderParent = new GameObject("Defenders");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown(){
		Vector2 rawPos = CalculateWorldPointOfMouseClick();
		Vector2 roundedPos = SnapToGrid(rawPos);
		
		GameObject defender = DefenderSelectButton.selectedDefender;
		int defenderCost = defender.GetComponent<Defenders>().starCost;
		
		if(starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS){
			GameObject defSpawn = Instantiate(DefenderSelectButton.selectedDefender,roundedPos,Quaternion.identity) as GameObject;
			defSpawn.transform.parent = defenderParent.transform;
		} else {
			print ("You have insufficient funds") ;
		}
		
	}
	
	Vector2 SnapToGrid (Vector2 rawWorldPos){
		float x = Mathf.Round(rawWorldPos.x);
		float y = Mathf.Round(rawWorldPos.y);
		
		return new Vector2(x,y);
		
	}
	
	Vector2 CalculateWorldPointOfMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
	
		Vector3 triplet = new Vector3(mouseX,mouseY,distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(triplet);
		
		//worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x,mousePos.y,mousePos.z));
		return worldPos;
	}
}
