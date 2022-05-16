using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BigBoss_spikes : MonoBehaviour {

       public GameHandler gameHandlerObj;
       public int damage = 5;
       //public Transform backToStart; //uncomment this line for "auto-death," to zap the Player back to start

       void Start(){
            if (GameObject.FindWithTag("GameHandler") != null){
               gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            }
       }

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			gameHandlerObj.playerGetHit(damage);
			//other.transform.position = new Vector3(backToStart.position.x, backToStart.position.y, backToStart.position.z);
			Debug.Log("I spiked the player!");
			Destroy(gameObject);	
		}
	}
}