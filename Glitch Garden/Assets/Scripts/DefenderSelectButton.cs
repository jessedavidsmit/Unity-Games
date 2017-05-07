using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DefenderSelectButton : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;
	
	
	private static string nameSelectedButton;
	private Text costText;
	
	
	// Use this for initialization
	void Start () {
		costText = this.GetComponentInChildren<Text>();
		costText.text = defenderPrefab.GetComponent<Defenders>().starCost.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if(nameSelectedButton != name) {
			this.GetComponent<SpriteRenderer>().color = Color.black;
		}
	}
	
	void OnMouseDown(){
		this.GetComponent<SpriteRenderer>().color = Color.white;
		nameSelectedButton = name;
		selectedDefender = defenderPrefab;
			
	}
}
