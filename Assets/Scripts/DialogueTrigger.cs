using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Queue<string> dialogue = new Queue<string>();
    public string Name;
    public TextAsset File;
    public int pos;
      private void onDialogTrigger(){
         if(File != null){
            string txt = File.text;
            string[] lines = txt.Split(System.Environment.NewLine.ToCharArray());
            getDialogue(lines);
            FindObjectOfType<DialogueManager>().StartDialogue(Name, dialogue);
         }
      }

      private void getDialogue(string[] lines){
         bool canQueue = false;
         bool hasQueue = false;
         foreach (string line in lines){
            if(!string.IsNullOrEmpty(line)){
               if(line.StartsWith("[")){
                  int getPos = int.Parse(line.Substring(1,1));
                  if(getPos == pos)
                  {
                     canQueue = true;
                     hasQueue = true;
                  } else {
                     if(hasQueue){
                        break;
                     } 
                     canQueue = false;
                  }
               } else if(line.StartsWith("{")) {
                  if(canQueue){
                     int getPos = int.Parse(line.Substring(1,1));
                     pos = getPos;
                  }
               } else {
                  if(canQueue){
                     dialogue.Enqueue(line);
                  }
               }
            }
         }
         dialogue.Enqueue("ENDQUEUE");
      }
     private void OnTriggerEnter2D(Collider2D collision)
     {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameEvents.current.onDialogueTrigger += onDialogTrigger;
        }
     }
     private void OnTriggerExit2D(Collider2D collision)
     {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameEvents.current.onDialogueTrigger -= onDialogTrigger;
        }
     }
}
