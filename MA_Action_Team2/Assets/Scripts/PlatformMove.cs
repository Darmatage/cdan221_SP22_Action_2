using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlatformMove : MonoBehaviour {

       private float speed = 2f;
       private bool moveToA = true;
       public Transform moveTargetA;
       public Transform moveTargetB;
       private Vector3 mTA;
       private Vector3 mTB;

       void FixedUpdate(){
              mTA = new Vector3(moveTargetA.position.x, moveTargetA.position.y, 0);
              mTB = new Vector3(moveTargetB.position.x, moveTargetB.position.y, 0);
              float step = speed * Time.deltaTime;        // calculate distance to move

              if (moveToA){
                     transform.position = Vector3.MoveTowards(transform.position, mTA, step);
              } else {
                     transform.position = Vector3.MoveTowards(transform.position, mTB, step);
              }

              if (Vector3.Distance(moveTargetA.position, transform.position) < 1){moveToA = false;}
              else if (Vector3.Distance(moveTargetB.position, transform.position) < 1){moveToA = true;}
       }

       void OnCollisionEnter2D(Collision2D other){
              if (other.gameObject.tag == "Player"){
                     other.collider.transform.SetParent(transform);        // so Player moves with platform
              }
       }

       void OnCollisionExit2D(Collision2D other){
              if (other.gameObject.tag == "Player"){
                     other.collider.transform.SetParent(null);        // Player not parented when off platform
              }
       }

}
