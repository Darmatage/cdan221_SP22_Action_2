using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class NPC_PatrolSequencePoints : MonoBehaviour {

	public float speed = 10f;
	private float waitTime;
	public float startWaitTime = 2f;

	public Transform[] moveSpots;
	public int startSpot = 0;
	public bool moveForward = true;
	
	// Turning
	public int nextSpot;
	public int previousSpot;  
	public bool faceRight = true;
	
	
	void Start(){
		waitTime = startWaitTime;
		nextSpot = startSpot;
	}

	void Update(){
		transform.position = Vector2.MoveTowards(transform.position, moveSpots[nextSpot].position, speed * Time.deltaTime);

		if (Vector2.Distance(transform.position, moveSpots[nextSpot].position) < 0.2f){
			if (waitTime <= 0){
				if (moveForward == true){ previousSpot = nextSpot; nextSpot += 1;}
				else if (moveForward == false){previousSpot = nextSpot; nextSpot -= 1;}
				waitTime = startWaitTime;
			} else {
				waitTime -= Time.deltaTime;
			}
		}

		//switch moveemnt direction
		if (nextSpot == 0) {moveForward = true;}
		else if (nextSpot == (moveSpots.Length -1)) {moveForward = false;}
			 
		//turning the enemy, WIP
		if (previousSpot < 0){previousSpot = moveSpots.Length -1;}
		else if (previousSpot > moveSpots.Length -1){previousSpot = 0;}
		
		if ((previousSpot == 0)&&(!faceRight)){enemyTurn();}
		else if ((previousSpot == (moveSpots.Length -1))&&(faceRight)) {enemyTurn();}
		
		
		
		// if (((MovingRight())&&(faceRight))||((MovingRight()==false)&&(!faceRight))){
			// enemyTurn();
		// }
    }
	
	
	// public bool MovingRight(){
		// if (moveSpots[nextSpot].position.x < moveSpots[previousSpot].position.x){
			// return true; 
		// }
		// return false;
	// }
	
	private void enemyTurn(){
		// NOTE: Switch player facing label (avoids constant turning)
		faceRight = !faceRight;

		// NOTE: Multiply player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	
}