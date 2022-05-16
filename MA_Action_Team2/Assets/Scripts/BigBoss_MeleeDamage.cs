using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BigBoss_MeleeDamage : MonoBehaviour {
	private Renderer rend;
	public Animator anim;
	//public GameObject healthLoot;
	public int maxHealth = 300;
	public int currentHealth;

	public BigBoss_Behavior bigBoss;
	
	public GameObject finalBarrier;

	public GameObject goodbyeMSG;
	public float displayMSGTime = 10f;
		

	void Start(){
		Debug.Log("Start() function is working");
		bigBoss = GetComponent<BigBoss_Behavior>();
		currentHealth = maxHealth;
		rend = GetComponentInChildren<Renderer>();
		anim = GetComponentInChildren<Animator>();
		goodbyeMSG.SetActive(false);
	}

	public void TakeDamage(int damage){
		currentHealth -= damage;
		rend.material.color = new Color(2.4f, 0.9f, 0.9f, 1f);
		StartCoroutine(ResetColor());
		anim.SetTrigger ("Hurt");
		if (currentHealth <= 0){
			bigBoss.startBoss = false;
			Concede();
		}
	}


       void Concede(){
              //Instantiate (healthLoot, transform.position, Quaternion.identity);
              anim.SetBool ("Concede", true);
			  finalBarrier.SetActive(false);
              GetComponent<Collider2D>().enabled = false;
              StartCoroutine(ConcedeMsg());
       }

       IEnumerator ConcedeMsg(){
              goodbyeMSG.SetActive(true);
			  yield return new WaitForSeconds(displayMSGTime);
			  goodbyeMSG.SetActive(false);
       }

       IEnumerator ResetColor(){
              yield return new WaitForSeconds(0.5f);
              rend.material.color = Color.white;
       }
}