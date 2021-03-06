using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyPatrolHit : MonoBehaviour {

	public Animator anim;

    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask groundLayers;
    public Transform groundCheck;
    bool isFacingRight = true;
    RaycastHit2D hit;
	public float rayDistance = 1f;

    public int damage = 10;
    private GameHandler gameHandler;

    void Start(){
		anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //anim.SetBool("Walk", true);
        if (GameObject.FindWithTag ("GameHandler") != null) {
            gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
        }
    }

    void Update(){
        hit = Physics2D.Raycast(groundCheck.position, -transform.up, rayDistance, groundLayers);
		Debug.DrawRay(groundCheck.position, -transform.up, Color.white, rayDistance, true); 
    }

    void FixedUpdate(){
        if (hit.collider != false){
            if (isFacingRight){
                rb.velocity = new Vector2(speed, rb.velocity.y);
            } else {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        } else {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1f);
        }
    }

	public void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			anim.SetTrigger("Attack");
			gameHandler.playerGetHit(damage);
			//rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
			//StartCoroutine(HitEnemy());
		}
	}

    public void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.tag == "Player") {
            //anim.SetBool("Attack", false);
        }
    }
}



