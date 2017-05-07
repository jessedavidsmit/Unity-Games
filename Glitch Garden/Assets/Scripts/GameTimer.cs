using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float timeRemaining;
	public AudioClip victorySound;
	
	private float startTime;
	private GameObject winLabel;
	private Slider slider;
	private LevelManager levelManager;
	private bool endLevel = false;

	// Use this for initialization
	void Start () {
		slider = this.GetComponent<Slider>();
		slider.maxValue = timeRemaining;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		winLabel = GameObject.Find ("Win Title");
		winLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		startTime = Time.timeSinceLevelLoad + Time.deltaTime;
		slider.value = startTime;
		if (slider.value >= slider.maxValue && endLevel == false){
			PlayVictorySound();
		}
	}
	
	void PlayVictorySound()
	{
		AudioSource.PlayClipAtPoint(victorySound,this.transform.position,PlayerPrefsManager.GetMasterVolume());
		endLevel = true;
		DestroyAllTaggedObjects();
		winLabel.SetActive(true);
		StartCoroutine(this.Delay());
		
	}
	
	//Destroy all objects with DestroyOnWin tag
	void DestroyAllTaggedObjects(){
		GameObject [] taggedObjectArray = GameObject.FindGameObjectsWithTag("DestroyOnWin");
		foreach(GameObject x in  taggedObjectArray){
			Destroy(x);
		}
	}
	
	IEnumerator Delay()
	{	
		yield return new WaitForSeconds(victorySound.length);	
		levelManager.LoadNextLevel();
	}
}
