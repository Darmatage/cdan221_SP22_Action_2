using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishBounce : MonoBehaviour{
	
	public Animator anim;
	public SpriteRenderer jellyFish;
	
    void Start(){
        anim = GetComponentInChildren<Animator>();
		jellyFish = GetComponentInChildren<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Player"){
			anim.SetTrigger("Bounce");
			StartCoroutine(ColorChange());
		}
    }
	
	IEnumerator ColorChange(){
		jellyFish.color = new Color(2f, 0.5f, 0.5f, 1f);
		yield return new WaitForSeconds(0.1f);
		jellyFish.color = Color.white;
	}
	
	
}
