using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;
	
	void Start(){
		projectileParent = GameObject.Find("Projectiles");
		animator = GetComponent<Animator>();
		SetMyLaneSpawner() ;
		
		if(!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}
	}
	
	private void Fire(){			
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
	
	void Update(){
		if(IsAttackerAheadInLane()){
			animator.SetBool("isAttacking", true);
		} else {	
			animator.SetBool("isAttacking", false);
			
		}
	}
	
	void SetMyLaneSpawner(){
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
		
		foreach(Spawner spawner in spawnerArray){
			if(spawner.transform.position.y == transform.position.y){
				myLaneSpawner = spawner;
				return;
			}	
		}	
		Debug.LogError("Can't find spawner in lanes");
	}
	
	
	bool IsAttackerAheadInLane(){
		if(myLaneSpawner.transform.childCount <= 0)	{
			return false;
		}
		
		foreach (Transform ts in myLaneSpawner.transform){
			if(ts.transform.position.x > this.transform.position.x){
				return true;
			}
		}
		//Attacker in lane, but behind us. 
		return false;
		
		
	}
}
