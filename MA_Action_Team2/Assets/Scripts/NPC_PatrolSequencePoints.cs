using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class NPC_PatrolSequencePoints : MonoBehaviour {

       public float speed = 10f;
       private float waitTime;
       public float startWaitTime = 2f;

       public Transform[] moveSpots;
       private int nextSpot;
       public int startSpot = 0;
	   private int previousSpot;
       public bool moveForward = true;


	private bool FaceRight = true;
	
	

	void Start(){
		waitTime = startWaitTime;
		nextSpot = startSpot;
	}

	void Update(){
		transform.position = Vector2.MoveTowards(transform.position, moveSpots[nextSpot].position, speed * Time.deltaTime);

		if (Vector2.Distance(transform.position, moveSpots[nextSpot].position) < 0.2f){
			if (waitTime <= 0){
				if (moveForward == true){nextSpot += 1;}
				else if (moveForward == false){nextSpot -= 1;}
				waitTime = startWaitTime;
			} else {
				waitTime -= Time.deltaTime;
			}
		}

		if (nextSpot == 0) {
			moveForward = true;
		}
		else if (nextSpot == (moveSpots.Length -1)) {
			moveForward = false;
		}
			 
		//turn the enemy, WIP
		previousSpot = nextSpot -1;
		if (previousSpot < 0){previousSpot = moveSpots.Length -1;}
		else if (previousSpot > moveSpots.Length -1){previousSpot = 0;}
		
		if (moveSpots[nextSpot].position.x < moveSpots[previousSpot].position.x){
			enemyTurn();
		}
    }
	
	
	private void enemyTurn(){
		// NOTE: Switch player facing label
		FaceRight = !FaceRight;

		// NOTE: Multiply player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	
}