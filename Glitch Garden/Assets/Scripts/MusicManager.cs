﻿using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource audioSource;
	
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(gameObject);
		Debug.Log("Don't destroy on load: " + name);
		
		
	}
	
	// Update is called once per frame
	void Start () {
		
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
		
	}
	
	void OnLevelWasLoaded(int level){
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log ("Playing clip: " + thisLevelMusic);
		
		if (thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	
	public void ChangeVolume(float volume){
		audioSource.volume = volume;
	}
}
