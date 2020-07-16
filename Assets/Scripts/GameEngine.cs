using UnityEngine;
using System;


public class GameEngine : MonoBehaviour
{   //public SaveData save;
    
    private static GameEngine instance;
    
    // Start is called before the first frame update
    public  Vector2 lastcheckpoint;
    //public SaveData saveData;
    void Awake()
    {
        if (instance == null)
        {   float xaxis,yaxis;
            instance = this;
            DontDestroyOnLoad(instance);
            xaxis = PlayerPrefs.GetFloat("xaxis", -4.15f);
            yaxis = PlayerPrefs.GetFloat("yaxis", 3.14f);
            lastcheckpoint = new Vector2(xaxis, yaxis);
            Debug.Log("loaded" + lastcheckpoint);
           // Debug.Log(PlayerPrefs.GetInt("level"));
            
        }
        else
        {
            Destroy(gameObject);
            
        }
    

    }

    
}
