using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

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
		
		Debug.Log("Fox triggered: " + collision.name);
		if(obj.GetComponent<GraveStone>()){
			animator.SetTrigger("Jump Trigger");
		} else {
			attcker.Attack(obj);
			animator.SetBool("isAttacking",true);
		}
		
	//	if(obj.GetComponent<GraveStone>()){
		//	animator.SetTrigger("Jump Trigger");
		//}
		
		
		
	}
}
