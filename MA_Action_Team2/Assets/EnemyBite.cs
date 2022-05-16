using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBite : MonoBehaviour{

	private GameHandler gameHandler;
	private Animator anim;
	public Transform AttackPoint;
	public float attackRange = 3;
	public int damage = 5;
	public LayerMask playerLayers;

    // Start is called before the first frame update
    void Start(){
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponentInChildren<GameHandler>();
		anim = GetComponentInChildren<Animator>();
    }

	
	void Attack(){
            anim.SetTrigger ("Attack");
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, playerLayers);
           
            foreach(Collider2D player in hitPlayer){
                  Debug.Log("We hit " + player.name);
                  gameHandler.playerGetHit(damage);
            }
	}
	
	//NOTE: to help see the attack sphere in editor:
      void OnDrawGizmos(){
           if (AttackPoint == null) {return;}
            Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
      }
	
}
