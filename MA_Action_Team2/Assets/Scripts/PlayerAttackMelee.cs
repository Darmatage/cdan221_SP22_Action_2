using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerAttackMelee : MonoBehaviour{

	public Animator animator;
	public Transform attackPt;
	public float attackRange = 0.5f;
	public float attackRate = 2f;
	private float nextAttackTime = 0f;
	public int attackDamage = 20;
	public int attackDamageShark = 40;
	public LayerMask enemyLayers;

	void Start(){
		animator = gameObject.GetComponentInChildren<Animator>();
	}

	void Update(){
		animator = GameHandler.CurrentPlayerAnimator;  
		
		if (Time.time >= nextAttackTime){
			if (Input.GetAxis("Attack") > 0){
				if (GameHandler.mutation4active == false){
					Attack();
				}
				nextAttackTime = Time.time + 1f / attackRate;
			} 
		}
	}

	void Attack(){
		animator.SetTrigger ("Melee");
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPt.position, attackRange, enemyLayers);
           
		foreach(Collider2D enemy in hitEnemies){
			Debug.Log("We hit " + enemy.name);
			if (GameHandler.mutation2active == true){   
				enemy.GetComponent<EnemyMeleeDamage>().TakeDamage(attackDamageShark);
			} else {
				enemy.GetComponent<EnemyMeleeDamage>().TakeDamage(attackDamage);
			}
		}
	}

      //NOTE: to help see the attack sphere in editor:
      void OnDrawGizmosSelected(){
           if (attackPt == null) {return;}
            Gizmos.DrawWireSphere(attackPt.position, attackRange);
      }
}