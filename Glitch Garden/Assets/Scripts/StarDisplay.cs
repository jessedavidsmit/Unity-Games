using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof (Text))]
public class StarDisplay : MonoBehaviour {
	
	private Text currencyText;
	public float currency = 5000;
	
	public enum Status {SUCCESS, FAILURE};
	
	// Use this for initialization
	void Start () {
		currencyText = GetComponent<Text>();
		currencyText.text = currency.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void AddStars(int amount) {
		currency += amount;
		currencyText.text = currency.ToString();
	}
	
	public Status UseStars(int amount){
		if (currency >= amount){
			currency -= amount;
			currencyText.text = currency.ToString();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
		
	}
}
