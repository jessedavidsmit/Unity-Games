using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	private float[] ballDirection = new float[] {-2f,2f};
	
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		if( !hasStarted)
		{
			//Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
				//Wait for a mouse press to launch.
				if(Input.GetMouseButtonDown(0))
				{
			
				print ("mouse clicked, lauch ball");
				hasStarted = true;
				//The x property is randomized to randomized ball play direction.
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(ballDirection[Random.Range(0,ballDirection.Length)],10f);
	
				}
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision){
	
		//Give the ball direction a little randomness when bouncing
		Vector2 tweak = new Vector2(Random.Range(0f,0.2f),Random.Range(0f,0.2f));
		
		
		if(hasStarted == true)
		{
	 		GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;
	 	}
	}
}
