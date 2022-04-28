using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerBottomRespawn : MonoBehaviour {

       public GameHandler gameHandler;
       public Transform playerPos;
       public Transform pSpawn;
       public int damage = 10;

       void Start() {
              playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
              gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
       }

       void Update() {
              if (playerPos != null){
                     if (transform.position.y >= playerPos.position.y){
                            //instantiate a particle effect
                            Debug.Log("I am going back to the start");
                            gameHandler.playerGetHit(damage);
                            Vector3 pSpn2 = new Vector3(pSpawn.position.x, pSpawn.position.y, playerPos.position.z);
                            playerPos.position = pSpn2;
                     }
              }
       }
}