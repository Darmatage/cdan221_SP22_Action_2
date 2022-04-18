using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMutations : MonoBehaviour
{
	
	public GameObject art_default;
	public GameObject art_EyeStalk;
	public GameObject art_Octolegs;
	public GameObject art_SharkTeeth;
	public GameObject art_PoisonDart;

	private GameHandler gameHandler;
		
    void Start(){
		art_default.SetActive(true);
		art_EyeStalk.SetActive(false);
		art_Octolegs.SetActive(false);
		art_SharkTeeth.SetActive(false);
		art_PoisonDart.SetActive(false);
		
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }

    void Update(){
        
		if (GameHandler.mutation1active == true){
			art_default.SetActive(false);
			art_EyeStalk.SetActive(true);
			art_Octolegs.SetActive(false);
			art_SharkTeeth.SetActive(false);
			art_PoisonDart.SetActive(false);
		}
		
		else if (GameHandler.mutation2active == true){
			art_default.SetActive(false);
			art_EyeStalk.SetActive(false);
			art_Octolegs.SetActive(true);
			art_SharkTeeth.SetActive(false);
			art_PoisonDart.SetActive(false);
		}
		
		else if (GameHandler.mutation3active == true){
			art_default.SetActive(false);
			art_EyeStalk.SetActive(false);
			art_Octolegs.SetActive(false);
			art_SharkTeeth.SetActive(true);
			art_PoisonDart.SetActive(false);
		}
		
		else if (GameHandler.mutation4active == true){
			art_default.SetActive(false);
			art_EyeStalk.SetActive(false);
			art_Octolegs.SetActive(false);
			art_SharkTeeth.SetActive(false);
			art_PoisonDart.SetActive(true);
		}
		
		else {
			art_default.SetActive(true);
			art_EyeStalk.SetActive(false);
			art_Octolegs.SetActive(false);
			art_SharkTeeth.SetActive(false);
			art_PoisonDart.SetActive(false);
		}
		
    }
}
