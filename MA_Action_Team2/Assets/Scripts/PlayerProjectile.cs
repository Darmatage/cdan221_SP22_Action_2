using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour{

      public int damage = 20;
      public GameObject hitEffectAnim;
      public float SelfDestructTime = 1.0f;
      public SpriteRenderer projectileArt;

      void Start(){
           projectileArt = GetComponentInChildren<SpriteRenderer>();
      }

	//if the bullet hits a collider, play the explosion animation, then destroy the effect and the bullet
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer("Enemies")) {
			//gameHandlerObj.playerGetHit(damage);
			other.gameObject.GetComponent<EnemyMeleeDamage>().TakeDamage(damage);
				  
			float pushBack = 0f;
			if (transform.position.x < other.gameObject.transform.position.x){
				pushBack = 3f;
			}else {
				pushBack = -3f;
			}
			Vector2 otherPos = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y);
			other.gameObject.transform.position = new Vector3(otherPos.x + pushBack, otherPos.y + 1f, 0);
		}
        
		if (other.gameObject.tag != "Player") {
            GameObject animEffect = Instantiate (hitEffectAnim, transform.position, Quaternion.identity);
            projectileArt.enabled = false;
			gameObject.GetComponent<Collider2D>().enabled = false;
            //Destroy (animEffect, 0.5);
            StartCoroutine(selfDestruct(animEffect));
        }
    }

	IEnumerator selfDestruct(GameObject VFX){
		yield return new WaitForSeconds(SelfDestructTime);
		Destroy (VFX);
		Destroy (gameObject);
	}
}