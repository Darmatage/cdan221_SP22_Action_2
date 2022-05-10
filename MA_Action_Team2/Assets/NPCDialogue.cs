using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour {
       //private Animator anim;
       private NPCDialogueManager dialogueMNGR;
       public string[] dialogue; //enter dialogue lines into the inspector for each NPC
       public bool playerInRange = false; //could be used to display an image: hit [e] to talk
       public int dialogueLength;

       void Start(){
              //anim = gameObject.GetComponentInChildren<Animator>();
              dialogueLength = dialogue.Length;
              if (GameObject.FindWithTag("DialogueManager")!= null){
                     dialogueMNGR = GameObject.FindWithTag("DialogueManager").GetComponent<NPCDialogueManager>();
              }
       }

       private void OnTriggerEnter2D(Collider2D other){
              if (other.gameObject.tag == "Player") {
                     playerInRange = true;
                     dialogueMNGR.LoadDialogueArray(dialogue, dialogueLength);
                     dialogueMNGR.OpenDialogue();
                     //anim.SetBool("Chat", true);
                     //Debug.Log("Player in range");
              }
       }

       private void OnTriggerExit2D(Collider2D other){
              if (other.gameObject.tag =="Player") {
                     playerInRange = false;
                     dialogueMNGR.CloseDialogue();
                     //anim.SetBool("Chat", false);
                     //Debug.Log("Player left range");
              }
       }
}