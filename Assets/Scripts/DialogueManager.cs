using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences = new Queue<string>();

    private string Name; 
    public void StartDialogue (string name, Queue<string> dialogue)
    {
        sentences = dialogue;
        Name = name;
        printDialogue();
    }

    public void printDialogue(){
        if(sentences.Count == 0 || sentences.Peek().Contains("ENDQUEUE"))
        {
            sentences.Dequeue();
            endDialogue();
        } else {
            Debug.Log(sentences.Dequeue());
        }
    }
    public void endDialogue()
    {
        Debug.Log("End of Conversation");
    }

}
