using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	
	public static int score;
	
	public static void ScoreKeep(int x){
		score += x;
	}
	
	void Start()
	{
		ResetScore();
	}
	
	public void ResetScore(){
		Debug.Log("Resetting Score");
		score = 0;
	}
	
	void Update(){
		Text scoreText = GetComponent<Text>();
		scoreText.text = "Score: " + score;
	}
}
