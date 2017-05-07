using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {
	
	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;
	private GameObject currentTarget;
	private float currentSpeed;
	private Animator animator;
	
	void Start(){
		animator = GetComponent<Animator>();
	}
	
	void OnTriggerEnter2D(Collider2D collision){
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if(!currentTarget){
			animator.SetBool("isAttacking",false);
		}
	}
	
	public void setSpeed(float speed){
		currentSpeed = speed;
	}
	
	public void StrikeCurrentTarget(float damage){
		if(currentTarget){
			Health health = currentTarget.GetComponent<Health>();
			if(health){
				health.DealDamage(damage);
			}
		}
		
	}
	
	public void Attack(GameObject obj){
		currentTarget = obj;
	}
}
