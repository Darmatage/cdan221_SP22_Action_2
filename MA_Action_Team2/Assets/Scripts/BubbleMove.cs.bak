using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMove : MonoBehaviour{
	
	//Bubble Up Moving
	public float timeToPop = 2f;
	public float upSpeed;
	
	private Vector2 bubbleStart;
	private Vector2 bubbleEnd;
	
	
	//Bubble side-to-side moving
	public float speedS = 0.05f;
	public float distS = 0.05f;

	//extra parameters for randomizing movement
	private float randLeft = 0.06f;
	private float randRight = 0.1f;

	private bool SinWaveMove = true;
	private bool randomizeSin = true;
	
	
	
	
    void Start(){
        PopBubble();
		bubbleStart = (Vector2)transform.position;
		bubbleEnd = new Vector2(bubbleStart.x, bubbleStart.y + 25f);
		
		//randomize side-to-side distance
		if (randomizeSin==true){
			speedS = (speedS * Random.Range(randLeft, randRight));
		}
		
		//ranmdomize upSpeed
		upSpeed = Random.Range(0.2f, 1f);
    }


	void Update(){
		//use Mathf.Sin function to move up and down
		//if (SinWaveMove == true){
			//transform.position = startPos + new Vector3((Mathf.Sin(Time.time * speedS) * distS), 0.0f,  0.0f);
		//}
	}

    void FixedUpdate(){
		//move upward
		Vector2 pos = Vector2.Lerp ((Vector2)transform.position, bubbleEnd, upSpeed * Time.fixedDeltaTime);
		transform.position = new Vector2 (pos.x + (Mathf.Sin(Time.time * speedS) * distS), pos.y);
    }
	
	IEnumerator PopBubble(){
		yield return new WaitForSeconds(timeToPop);
		Destroy (gameObject);
	}
	
}
