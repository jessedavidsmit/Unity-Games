using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {
	
	private Animator animator;
	private Attacker attcker;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		attcker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collision){
		GameObject obj = collision.gameObject;
		
		if(!obj.GetComponent<Defenders>()){
			return;
		} 
		
		attcker.Attack(obj);
		animator.SetBool("isAttacking",true);
		
		
		
	}
}
