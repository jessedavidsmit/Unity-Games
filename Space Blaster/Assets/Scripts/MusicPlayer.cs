using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	
	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;
	
	private AudioSource Music;
	bool Menu = false;
	
	// Use this for initialization
	void Start () {
		Debug.Log("Music player start " + GetInstanceID());
		if(instance != null )
		{
			Destroy(gameObject);
			print ("Duplicate music player detroyed");
		}
		else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			Music = GetComponent<AudioSource>();
			Music.clip = startClip;
			Music.loop = true;
			Music.Play();
			
			
			
		}
	}
	
	void OnLevelWasLoaded(int level){
		Debug.Log("MusicPlayer: loaded level " + level);
		if (Application.loadedLevel == 0 || Application.loadedLevel == 4 ||   Application.loadedLevel == 5){
			Menu = true;
		}
		else if (Application.loadedLevel != 0 || Application.loadedLevel != 4 ||  Application.loadedLevel != 4)
		{
			Menu = false;
		}
		
		if(Menu == false ){
			Debug.Log("Stop Music");
			Music.Stop();		
		}
		
		if(level == 0){
			Music.clip = startClip;		
		}
		if(level == 1){
			Music.clip = gameClip;
		}
		if(level == 2 || level == 3){
			Music.clip = endClip;	
		}
		if(Menu == false || !Music.isPlaying )
		{
			Music.loop = true;
			Music.Play();
		}
	}
	
	
	
}
