using UnityEngine;

public class npcControl : MonoBehaviour
{
    // Start is called before the first frame update
    bool pressed_key;
    public Dialogue dialogue;
    public bool flag = false;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            pressed_key = true;
            flag = false;
        }
    }



    void OnTriggerExit2D(Collider2D other)
    {
        pressed_key = false;
    }
    void FixedUpdate()
    {
        if (pressed_key)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("flag = " + flag);
                if (!flag)
                {

                    flag = !flag;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    FindObjectOfType<PlayerMovemnt>().enabled = false;
                }
                else
                {

                    FindObjectOfType<DialogueManager>().DisplayNextSentence();

                }

            }

        }


    }


}



