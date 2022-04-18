using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp_UpDown : MonoBehaviour{

      //initial values, can be made public
      private Vector3 startPos;

      public float speedS = 2.5f;
      public float distS = 0.5f;

      //extra parameters for randomizing movement
      private float randBottom = 0.6f;
      private float randTop = 1f;

      private bool SinWaveMove = true;
      private bool randomizeSin = true;

      void Start(){
            startPos = transform.position;

            //randomize distance
            if (randomizeSin==true){
                  speedS = (speedS * Random.Range(randBottom, randTop));
            }
      }

      void Update (){
            //use Mathf.Sin function to move up and down
            if (SinWaveMove == true){
                  transform.position = startPos + new Vector3(0.0f, (Mathf.Sin(Time.time * speedS) * distS), 0.0f);
            }
      }
}