using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickContinue()
    {   

        int level = PlayerPrefs.GetInt("level", 1);
        PlayerPrefs.SetInt("isNextLevel", 0);
        PlayerPrefs.SetInt("isNewGame", 0);
        SceneManager.LoadScene(level);
        

    }

    public void OnClickNew()
    {   
        PlayerPrefs.SetInt("isNextLevel", 0);
        PlayerPrefs.SetInt("isNewGame", 1);
        SceneManager.LoadScene(1);

    }
}
