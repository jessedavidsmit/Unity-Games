using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float damage = 100f;
	public GameObject projectileExplosion;
	
	public void Hit(){
		Destroy(gameObject);
		GameObject p_explo = Instantiate(projectileExplosion,transform.position,Quaternion.identity) as GameObject;
		Destroy(p_explo,2f);
	}
	
	public float GetDamage(){
		return damage;
	}
}
