using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerHurt: MonoBehaviour{

      public Animator animator;
      public Rigidbody2D rb2D;
	  public AudioSource hitSFX;

      void Start(){
           //animator = gameObject.GetComponentInChildren<Animator>();
           rb2D = transform.GetComponent<Rigidbody2D>();
      }

	void Update(){
		animator = GameHandler.CurrentPlayerAnimator;
	}
		

      public void playerHit(){
            animator.SetTrigger ("GetHurt");
			hitSFX.Play();
      }

      public void playerDead(){
            rb2D.isKinematic = true;
            animator.SetTrigger ("Dead");
      }
}
