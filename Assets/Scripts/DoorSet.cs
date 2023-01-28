using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSet : MonoBehaviour
{
    public bool doorState = true;

    private void onDoorAction() {
        if(doorState == true){
            //Open Door: gameObject.SetActive(false);

            doorState = false;
        } else if(doorState == false){
            //Close Door: gameObject.SetActive(true);

            doorState = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
     {
        if(collision.gameObject.CompareTag("Player")){
            GameEvents.current.onDialogueTrigger +=  onDoorAction;
        }
     }
     private void OnTriggerExit2D(Collider2D collision)
     {
        if(collision.gameObject.CompareTag("Player")){
            GameEvents.current.onDialogueTrigger -=  onDoorAction;
        }
     }


}
