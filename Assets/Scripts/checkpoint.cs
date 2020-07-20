using UnityEngine;

public class checkpoint : MonoBehaviour
{
    private GameEngine gameEngine;

    void Start()
    {
        gameEngine = FindObjectOfType<GameEngine>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameEngine.lastcheckpoint = FindObjectOfType<PlayerMovemnt>().transform.position;
            FindObjectOfType<PlayerPref>().Save();
        }
    }

  
}
