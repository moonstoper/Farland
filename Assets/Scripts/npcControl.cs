using UnityEngine;

public class npcControl : MonoBehaviour
{
    // Start is called before the first frame update
    bool in_region;
    public Dialogue dialogue;
    public bool flag = false;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            in_region= true;
            flag = false;
        }
    }



    void OnTriggerExit2D(Collider2D other)
    {
        in_region = false;
        flag = false;
    }
    void Update()
    {
        if (in_region)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (flag == false)
                {

                    flag = true;
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



