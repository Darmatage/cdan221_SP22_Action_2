using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoss_SpikeDropper : MonoBehaviour
{

      //Object variables
      public GameObject spikePrefab;
      public Transform[] spawnPoints;
      private int rangeEnd;
      private Transform spawnPoint;

      //Timing variables
      public float spawnRangeStart = 0.1f;
      public float spawnRangeEnd = 0.5f;
      private float timeToSpawn;
      private float spawnTimer = 0f;


	public bool canDropSpikes = false;

      void Start(){
              //assign the length of the array to the end of the random range
             rangeEnd = spawnPoints.Length - 1 ;
       }

	void FixedUpdate(){
		if (canDropSpikes){  
			timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);
			spawnTimer += 0.01f;
			if (spawnTimer >= timeToSpawn){
                  spawnSpikes();
                  spawnTimer =0f;
			}
		}
	}

      void spawnSpikes(){
            int SPnum = Random.Range(0, rangeEnd);
            spawnPoint = spawnPoints[SPnum];
            Instantiate(spikePrefab, spawnPoint.position, Quaternion.identity);
      }
}

