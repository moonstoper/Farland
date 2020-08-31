using UnityEngine;

public class npcControl : MonoBehaviour
{
    // Start is called before the first frame update
    bool in_region;
    public Dialogue dialogue;
    public bool flag = false;

    public GameObject popUp;
    GameObject pop;
    private Vector2 position;
    void Start()
    {
        // position = this.gameObject.transform.position;
        // popUp.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            in_region = true;
            flag = false;

            // Instantiate(popUp,)

            Vector3 position = this.gameObject.transform.position;
            position = new Vector3(position.x, position.y + 2, position.z);
            pop = Instantiate(popUp, position, Quaternion.identity);
        }
    }



    void OnTriggerExit2D(Collider2D other)
    {
        in_region = false;
        flag = false;
        Destroy(pop, .5f);
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
                    FindObjectOfType<PlayerMovement>().enabled = false;
                }
                else
                {

                    FindObjectOfType<DialogueManager>().DisplayNextSentence();

                }

            }

            // popUp.SetActive(true);

        }


    }


}



