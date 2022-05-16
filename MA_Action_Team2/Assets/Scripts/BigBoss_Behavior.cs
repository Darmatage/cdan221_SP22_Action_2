using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoss_Behavior : MonoBehaviour{

	public int biteDamage = 20;
	public int tailDamage = 10;
	private Animator anim;
	private GameHandler gameHandler;
	
	public bool canRoar = true;
	public bool canBite = false;
	public bool canTail = false;
	
	public bool Roaring = false;
	public bool Biting = false;
	public bool TailSwinging = false;

	public GameObject SpikeDropSystem;
	public BigBoss_PlayerCanGetHit BiteCollider;
	public BigBoss_PlayerCanGetHit TailCollider;
	public CameraScreenShake cameraScreenShake;

	//private float bossTimer = 0;
	private float roarTimer=0;  
	private float biteTimer=0; 	
	private float tailTimer=0; 	
	public float timeToRoar = 2f;
	public float timeToBite = 2f;
	public float timeToTail = 2f;


	public bool startBoss = false;
	
    void Start(){
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponentInChildren<GameHandler>();
		anim = GetComponentInChildren<Animator>();
		cameraScreenShake = GameObject.FindWithTag("MainCamera").GetComponent<CameraScreenShake>();

    }


    void FixedUpdate(){
        if (startBoss){
			if (canRoar){
				roarTimer += 0.01f;
				if (roarTimer >= timeToRoar){
					StopCoroutine(RoarDropSpikes());
					StartCoroutine(RoarDropSpikes());
					Debug.Log("time to drop spikes!");
					roarTimer = 0;
				}
			}
		
			if (canBite){
				biteTimer += 0.01f;
				if (biteTimer >= timeToBite){
					StopCoroutine(BiteAttack());
					StartCoroutine(BiteAttack());
					Debug.Log("time to Bite!");
					biteTimer = 0;
				}
			}
			
			if (canTail){
				tailTimer += 0.01f;
				if (tailTimer >= timeToTail){
					StopCoroutine(TailSwipeAttack());
					StartCoroutine(TailSwipeAttack());
					Debug.Log("time to Tail!");
					tailTimer = 0;
				}
			}
		}
    }


	IEnumerator RoarDropSpikes(){
		anim.SetBool("Roar", true);
		Roaring = true;
		SpikeDropSystem.GetComponent<BigBoss_SpikeDropper>().canDropSpikes = true;
		cameraScreenShake.ShakeCamera(2f, 0.3f);
		yield return new WaitForSeconds(3f);
		SpikeDropSystem.GetComponent<BigBoss_SpikeDropper>().canDropSpikes = false;
		anim.SetBool("Roar", false);
		Roaring = false;
		canRoar = false;
		canBite = true;
	}

	IEnumerator BiteAttack(){
		if (BiteCollider.isPlayerHere()){
			gameHandler.playerGetHit(biteDamage);
			Debug.Log("BigBoss bit the player!");
		}
		anim.SetBool("Bite", true);
		Biting = true;
		cameraScreenShake.ShakeCamera(1f, 0.2f);
		yield return new WaitForSeconds(1f);
		anim.SetBool("Bite", false);
		Biting = false;
		canBite = false;
		canTail = true;
	}

	IEnumerator TailSwipeAttack(){
		if (TailCollider.isPlayerHere()){
			gameHandler.playerGetHit(tailDamage);
			Debug.Log("BigBoss hit the player with a tail!");
		}
		anim.SetBool("Tail", true);
		TailSwinging = true;
		cameraScreenShake.ShakeCamera(1f, 0.2f);
		yield return new WaitForSeconds(1f);
		anim.SetBool("Tail", false);
		TailSwinging = false;
		canTail = false;
		canRoar = true;
	}

	//NOTE: to help see the attack sphere in editor:
      void OnDrawGizmos(){
            //Gizmos.DrawWireSphere(startPoint.position, startRange);
			//Gizmos.DrawWireSphere(AttackPoint.position, damageRange);
    }

}


	//meelee damage for biting
	//melee damage for tailswing