using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	
	private BallScript ball;
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay){
			MoveWithMouse();
		}
		else {
			AutoPlay();
		}
		
	}
	
	void Start(){
		ball = GameObject.FindObjectOfType<BallScript>();
		
	}
	
	void AutoPlay(){
		Vector3 paddlePos = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x,1.0f,15.0f);
		this.transform.position = paddlePos;
	}
	
	void MoveWithMouse(){
		Vector3 paddlePos = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width *16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks,1.0f,15.0f);
		this.transform.position = paddlePos;
	}
}
