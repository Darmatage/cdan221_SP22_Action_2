using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour{

      //Object variables
      public Transform[] spawnPoints;
	  public GameObject[] bubbles;      

      private int spRangeEnd;
	  private int bubRangeEnd;
	  
      private Transform spawnPoint;
	  private GameObject bubblePrefab;

      //Timing variables
      public float spawnRangeStart = 0.5f;
      public float spawnRangeEnd = 1.2f;
      private float timeToSpawn;
      private float spawnTimer = 0f;

      void Start(){
              //assign the length of the array to the end of the random range
             spRangeEnd = spawnPoints.Length - 1 ;
			 bubRangeEnd = bubbles.Length - 1 ;
       }

      void FixedUpdate(){
            timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);
            spawnTimer += 0.01f;
            if (spawnTimer >= timeToSpawn){
                  spawnBubble();
                  spawnTimer =0f;
            }
      }

      void spawnBubble(){
            //ranmdomize location to spawn
			int SPnum = Random.Range(0, spRangeEnd);
            spawnPoint = spawnPoints[SPnum];
			
			//randomize which bubble spawns
			int bubbleNum = Random.Range(0, bubRangeEnd);
			bubblePrefab = bubbles[bubbleNum];
			
            Instantiate(bubblePrefab, spawnPoint.position, Quaternion.identity);
      }
}