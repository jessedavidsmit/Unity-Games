using UnityEngine;
using System.Collections;

public class GraveStone : MonoBehaviour {

	private Animator animator;
	
	void Start(){
		animator = GetComponent<Animator>();
	}
	
	void Update(){
		
	}
	
	void OnTriggerStay2D (Collider2D col){
		Attacker attacker = col.gameObject.GetComponent<Attacker>();
		
		if(attacker){
			animator.SetTrigger("UnderAttackTrigger");
		}
		
	}
}
