using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public Animator animator;
    public Rigidbody2D rb2D;
    private bool FaceRight = true; // determine which way player is facing.
    public static float runSpeed = 10f;
    public float startSpeed = 10f;
    public bool isAlive = true;
    //public AudioSource WalkSFX;
	public Vector3 hMove;
	public LayerMask climbable;
	public bool canClimbNow;

	public Animator p0anim;
	public Animator p1anim;
	public Animator p2anim;
	public Animator p3anim;
	public Animator p4anim;


	void Start(){
		//animator = gameObject.GetComponentInChildren<Animator>();
		rb2D = transform.GetComponent<Rigidbody2D>();
		climbable = LayerMask.NameToLayer("Climbable");
	}

	void Update(){
		animator = GameHandler.CurrentPlayerAnimator;
		
		// if (GameHandler.mutation3active == true){  
			// Debug.Log("mutation3active == true");
			// canClimbNow = true;
			// rb2D.isKinematic = true; // turns off gravity!
		// }else {Debug.Log("mutation3active == false");}
		
		//NOTE: Horizontal axis: [a] / left arrow is -1, [d] / right arrow is 1   
		if (isAlive == true){
			if (canClimbNow == true){
				hMove = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
				transform.position = transform.position + hMove * runSpeed * Time.deltaTime;
			}else{
				hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
                transform.position = transform.position + hMove * runSpeed * Time.deltaTime;
            }

             //if ((Input.GetAxis("Horizontal") != 0)&&(canClimbNow == false)){
			Vector3 nullMove = new Vector3(0,0,0);
				 
            if ((hMove != nullMove)&&(canClimbNow == false)){
				animator.SetBool ("Walk", true);
				if(GameHandler.mutation3active == true){
					animator.SetBool ("Climb", false);
				}
            //       if (!WalkSFX.isPlaying){
            //             WalkSFX.Play();
            //      }
			} else if ((hMove != nullMove)&&(canClimbNow == true)){
				animator.SetBool ("Climb", true);
				animator.SetBool ("Walk", false);
			//       if (!WalkSFX.isPlaying){
            //             WalkSFX.Play();
            //      }
			} else if ((hMove == nullMove)&&(canClimbNow == true)){
				  animator.SetBool ("Climb", false);
				  animator.SetBool ("Walk", false);
			} else {
                  animator.SetBool ("Walk", false);
            //      WalkSFX.Stop();
            }

            // NOTE: if input is moving the Player right and Player faces left, turn, and vice-versa
           if ((hMove.x <0 && !FaceRight) || (hMove.x >0 && FaceRight)){
                  playerTurn();
            }
		}
	}

      void FixedUpdate(){
            //slow down on hills / stops sliding from velocity
            if (hMove.x == 0){
                  rb2D.velocity = new Vector2(rb2D.velocity.x / 1.1f, rb2D.velocity.y) ;
            }
      }

      private void playerTurn(){
            // NOTE: Switch player facing label
            FaceRight = !FaceRight;

            // NOTE: Multiply player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
      }
	  
	  
	public void OnTriggerEnter2D(Collider2D other){
		Debug.Log("I hit a trigger collider");
		if ((other.gameObject.layer == climbable)&&(GameHandler.mutation3active == true)){  
			canClimbNow = true;
			rb2D.isKinematic = true; // turns off gravity!
			GetComponent<PlayerBetterFall>().enabled=false;
		
			Debug.Log("the colider is climbable");
		}
	}
	  
	public void OnTriggerExit2D(Collider2D other){
		  if ((other.gameObject.layer == climbable)||(GameHandler.mutation3active == false)){
			canClimbNow = false;
			rb2D.isKinematic = false; // turns on gravity
			GetComponent<PlayerBetterFall>().enabled=true;
		}
	}
	  
}