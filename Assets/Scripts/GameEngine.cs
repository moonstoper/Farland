using UnityEngine;
using UnityEngine.SceneManagement;


public class GameEngine : MonoBehaviour
{   //public SaveData save;

    private static GameEngine instance;
    public bool newGame;

    // Start is called before the first frame update
    public Vector2 lastcheckpoint;
    //public SaveData saveData;
    void Awake()
    {
        if (instance == null)
        {  
            instance = this;
            DontDestroyOnLoad(instance);
            int checkLevelChange = PlayerPrefs.GetInt("isNextLevel", 0);
            int newGameCheck = PlayerPrefs.GetInt("isNewGame", 0);
            int level = PlayerPrefs.GetInt("level", 1);
            
            if( newGameCheck == 0 && level == SceneManager.GetActiveScene().buildIndex )
            {
                lastcheckpoint = new Vector2(PlayerPrefs.GetFloat("xaxis", -4.15f), PlayerPrefs.GetFloat("yaxis", 3.14f));
            }
            else
            {
                
                lastcheckpoint = new Vector2(-4.15f, 3.14f);
                FindObjectOfType<PlayerPref>().Save();
                
            }
            
           
            
            Debug.Log(SceneManager.GetActiveScene().buildIndex);


        }
        else
        {
            Destroy(gameObject);

        }


    }


}
