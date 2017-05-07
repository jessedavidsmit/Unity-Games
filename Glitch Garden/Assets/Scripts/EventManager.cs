using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {
	
	public AudioSource source;
	public AudioClip hoverSound;
	public AudioClip clickSound;

	public void OnHover(){
		source.PlayOneShot(hoverSound);
	}
	
	public void OnClick(){
		source.PlayOneShot(clickSound);
	}
}
