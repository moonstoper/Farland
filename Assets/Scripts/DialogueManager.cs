using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        Debug.Log("reached StartDialogue");
        dialogueText.text = "";

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }
        Debug.LogError(FindObjectOfType<npcControl>().flag);
        DisplayNextSentence();
        return;
    }

    public void DisplayNextSentence()
    {
        Debug.Log(sentences.Count);
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
        dialogueText.text = sentence;
        FindObjectOfType<npcControl>().flag = true;
        return;
    }
    void EndDialogue()
    {
        Debug.Log("End of converstion");
        sentences.Clear();
        dialogueText.text = "";
        FindObjectOfType<npcControl>().flag = false;
        FindObjectOfType<PlayerMovemnt>().enabled = true;
    }

}
