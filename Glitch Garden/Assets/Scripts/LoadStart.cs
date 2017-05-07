using UnityEngine;
using System.Collections;

public class LoadStart : MonoBehaviour {

	public float loadNextLevelAfter;

	// Use this for initialization
	void Start () {
		StartCoroutine(this.Wait());
	}
	
	
	
	IEnumerator Wait( )
	{
		yield return new WaitForSeconds(loadNextLevelAfter);
		float fadeTime = GameObject.Find ("LevelFader").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel("01 Start");
	}
}
