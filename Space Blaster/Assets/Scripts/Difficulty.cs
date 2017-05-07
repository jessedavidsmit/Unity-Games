using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Difficulty : MonoBehaviour {

	public static string difficulty;
	
	public void selectedDifficulty(string name)
	{
		difficulty = name;
	}
	
}
