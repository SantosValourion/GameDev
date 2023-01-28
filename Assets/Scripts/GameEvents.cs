using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    private void Awake(){
        current = this;
    }

    //Door Event
    public event Action onDoorTrigger;
    public void DoorTrigger() {
        if(onDoorTrigger != null){
            onDoorTrigger();
        }
    }

    //Dialog Event
    public event Action onDialogueTrigger;
    public void DialogueTrigger() {
        if(onDialogueTrigger != null){
            onDialogueTrigger();
        }
    }
}
