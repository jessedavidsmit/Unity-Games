using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {


	public void LoadLevel(string name)
	{
		Debug.Log ("Level load requested: " + name);
		
		//Reset the number of bricks per level 0
		//BrickScript.breakableCount = 0;
		StartCoroutine(this.FadingIE(name));
		
	}
	
	
	
	IEnumerator FadingIE(string name )
	{
	
		float fadeTime = GameObject.Find ("LevelFader").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		
		Application.LoadLevel(name);
	}
	
	public void QuitRequest()
	{
		Debug.Log ("Quit Game");
		Application.Quit();
	}
	
	public void LoadNextLevel()
	{		
		Application.LoadLevel(Application.loadedLevel + 1);
		
	}
	

	
	
}
