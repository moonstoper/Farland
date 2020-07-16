using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Razor : MonoBehaviour
{
    //private GameEngine gameEngine;
    void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<PlayerPref>().ReloadTolastCheckpoint();
    }

    // Start is called before the first frame update
}
