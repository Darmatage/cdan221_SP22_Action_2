using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoss_Start : MonoBehaviour{

	public BigBoss_Behavior bigBoss;
	
	
    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
			bigBoss.startBoss = true;
			Debug.Log("You have crossed the Rubicon!");
		}
		
    }
}
