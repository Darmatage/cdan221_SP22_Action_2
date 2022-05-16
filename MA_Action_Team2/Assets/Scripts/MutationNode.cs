using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutationNode : MonoBehaviour{
	
	// public float effectRange = 3f;

	public bool isMutation1 = true;
	public bool isMutation2 = false;
	public bool isMutation3 = false;
	public bool isMutation4 = false;

	public AudioSource mutationSFX;

	void Start(){
		mutationSFX = GetComponent<AudioSource>();
	}


    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
			mutationSFX.Play();
			StartCoroutine(destroyMutationNode());
			
			if (isMutation1){
				//GameHandler.mutation1enabled = true;
				GameHandler.mutation1active = true;
				GameHandler.mutation2active = false;
				GameHandler.mutation3active = false;
				GameHandler.mutation4active = false;
				
				GameHandler.mutationStamina = 100f;
				Debug.Log("mutation1 acquired!");
				}
			else if (isMutation2){
				//GameHandler.mutation2enabled = true;
				GameHandler.mutation1active = false;
				GameHandler.mutation2active = true;
				GameHandler.mutation3active = false;
				GameHandler.mutation4active = false;
				GameHandler.mutationStamina = 100f;
				}
			else if (isMutation3){
				//GameHandler.mutation3enabled = true;
				GameHandler.mutation1active = false;
				GameHandler.mutation2active = false;
				GameHandler.mutation3active = true;
				GameHandler.mutation4active = false;
				GameHandler.mutationStamina = 100f;
				}
			else if (isMutation4){
				//GameHandler.mutation4enabled = true;
				GameHandler.mutation1active = false;
				GameHandler.mutation2active = false;
				GameHandler.mutation3active = false;
				GameHandler.mutation4active = true;
				GameHandler.mutationStamina = 100f;
				}
		
		}
    }
	
	IEnumerator destroyMutationNode(){
		yield return new WaitForSeconds(0.5f);
		Destroy (gameObject);
	}
	
	
	//NOTE: to help see the attack sphere in editor:
    // void OnDrawGizmos(){
       // Gizmos.DrawWireSphere(transform.position, effectRange);
    // }
}
