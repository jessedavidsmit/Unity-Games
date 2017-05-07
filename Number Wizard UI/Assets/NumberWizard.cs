using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour 
{

	int max;
	int min;
	int guess;
	
	int maxGuessesAllowed = 10;
	
	public Text text;

	// Use this for initialization
	void Start ()
	{
		StartGame();
		text.text = "Is this your number " + guess.ToString() + " ?";	
	}
	
	void StartGame ()
	{
		max = 1000;
		min = 1;
		guess = Random.Range(min,max);
		
	
		max = max +1;
	}
	
	public void GuessHigher()
	{
		min = guess;
		NextGuess();
	}
	
	public void GuessLower()
	{
		max = guess;
		NextGuess();
	}
	

	
	void NextGuess()
	{
		guess = (max + min) / 2;
		text.text = "Is it " + guess.ToString() + " ?";
		maxGuessesAllowed = maxGuessesAllowed - 1;
		if(maxGuessesAllowed <= 0)
		{
			Application.LoadLevel("Win");
		}
		
	}
	
	
	
}
