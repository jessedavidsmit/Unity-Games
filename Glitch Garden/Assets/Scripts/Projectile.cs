using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D (Collider2D col){
		Attacker attacker = col.gameObject.GetComponent<Attacker>();
		Health health = col.gameObject.GetComponent<Health>();
		
	
		if(attacker && health){
			health.DealDamage(damage);
			Destroy(gameObject);
		} 
		
	}
	
	
}
