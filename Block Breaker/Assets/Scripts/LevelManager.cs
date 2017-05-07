using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
	{
		Debug.Log ("Level load requested: " + name);
		
		//Reset the number of bricks per level 0
		BrickScript.breakableCount = 0;
		
		Application.LoadLevel(name);
			
	}
	
	public void QuitRequest()
	{
		Debug.Log ("Quit Game");
		Application.Quit();
	}
	
	public void LoadNextLevel()
	{	
		//Reset the number of bricks per level 0
		BrickScript.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed()
	{
		if(BrickScript.breakableCount <= 0 )
		{
			LoadNextLevel();
		}
	}
	
	public void RetryLevel()
	{
		Application.LoadLevel(LoseCollider.currentLevel);
	}
	
	
}
