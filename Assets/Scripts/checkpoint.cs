using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    private GameEngine gameEngine;

    void Start()
    {
        gameEngine = GameObject.FindGameObjectWithTag("GameEngine").GetComponent<GameEngine>();
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
