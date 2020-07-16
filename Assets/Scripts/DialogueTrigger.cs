using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public void TriggerDialogue(Dialogue dialogue)
    {   //Debug.Log("Enter Triggered");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
