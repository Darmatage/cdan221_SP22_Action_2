using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoss_Start : MonoBehaviour{

	public BigBoss_Behavior bigBoss;
	public GameObject cameraMain;
	
	public GameObject welcomeMSG;
	public float displayWelcomeTime = 10f;
	
	void Start(){
		cameraMain = GameObject.FindWithTag("MainCamera");
		welcomeMSG.SetActive(false);
	}
	
    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
			bigBoss.startBoss = true;
			//cameraMain.GetComponent<Camera>().orthographicSize = 12;
			Debug.Log("You have crossed the Rubicon!");
			StartCoroutine(DisplayWelcome());
		}
		
    }
	
	IEnumerator DisplayWelcome(){
		welcomeMSG.SetActive(true);
		yield return new WaitForSeconds(displayWelcomeTime);
		welcomeMSG.SetActive(false);
	}
	
}
