using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoss_PlayerCanGetHit : MonoBehaviour{

	public bool playerIsHere = false;
	
	public bool isPlayerHere(){
		return playerIsHere;
	}
	
    public void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
			playerIsHere = true;
		}
    }
	
	public void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
			playerIsHere = false;
		}
    }
}
