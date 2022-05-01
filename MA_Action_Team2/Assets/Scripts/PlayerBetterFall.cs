using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerBetterFall : MonoBehaviour {

	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	Rigidbody2D rb2D;

	void Awake(){
		rb2D = GetComponent <Rigidbody2D> ();
	}

	void Update(){
		bool amIClimbing = GetComponent<PlayerMove>().canClimbNow;
		
		
		if ((rb2D.velocity.y < 0)&&(amIClimbing==false)) {
                  rb2D.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		} else if (rb2D.velocity.y > 0 && !Input.GetButton ("Jump")){
                  rb2D.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
		
      }
}