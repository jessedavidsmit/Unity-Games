using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public float shieldHealth = 100f;
	public AudioClip shieldDownSound;
	
	void OnTriggerEnter2D(Collider2D col){
		EnemyProjectile missle = col.gameObject.GetComponent<EnemyProjectile>();
		if(missle){
			shieldHealth -= missle.GetDamage();
			missle.Hit();	
			if(shieldHealth <= 0){
				AudioSource.PlayClipAtPoint(shieldDownSound,Camera.main.transform.position);
				Destroy(gameObject);
				PlayerController.shieldActive = false;
			}
		}
			
	}
	
	void Update(){
		this.transform.position = GameObject.Find ("PlayerShip").transform.position;
	}
	
	public void ReplaceShield(){
		Destroy(gameObject);
	}
}
