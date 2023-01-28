using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

     private void onDialogTrigger() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
     }

     private void OnTriggerEnter2D(Collider2D collision)
     {
        if(collision.gameObject.CompareTag("Player")){
            GameEvents.current.onDialogueTrigger +=  onDialogTrigger;
        }
     }
     private void OnTriggerExit2D(Collider2D collision)
     {
        if(collision.gameObject.CompareTag("Player")){
            GameEvents.current.onDialogueTrigger -=  onDialogTrigger;
        }
     }
}
