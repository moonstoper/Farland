using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerPref : MonoBehaviour
{
    // Start is called before the first frame update
    
    private GameEngine gameEngine;
   
    public int level;
    public Vector2 lastposition;
    public float xaxis,yaxis;
    public int health;
    
    public void Start()
    {
        gameEngine = FindObjectOfType<GameEngine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadTolastCheckpoint();
        }
     
      
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

      
    }

    public void ReloadTolastCheckpoint()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Save()
    {
            xaxis = gameEngine.lastcheckpoint.x;
            yaxis = gameEngine.lastcheckpoint.y;
            PlayerPrefs.SetFloat("xaxis", xaxis);
            PlayerPrefs.SetFloat("yaxis", yaxis);
            PlayerPrefs.SetInt("level", (int)SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.Save();
            Debug.Log("Saved");
    }

}
