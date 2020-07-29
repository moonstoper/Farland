using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public float typespeed;
    void Start()
    {
        sentences = new Queue<string>();

    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        dialogueText.text = "";
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        dialogueText.text = "";
        StartCoroutine(typeanim(sentence));
    }

    public void EndDialogue()
    {
        sentences.Clear();
        dialogueText.text = "";
        FindObjectOfType<PlayerMovemnt>().enabled = true;

    }

    IEnumerator typeanim(string sentence)
    {
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typespeed);
        }
    }
}

