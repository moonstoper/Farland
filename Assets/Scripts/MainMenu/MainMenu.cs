using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public LeanTween btn;
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

    public void OnCLickDelete()
    {
        GameObject btncontinue = GameObject.FindGameObjectWithTag("Continue");
        PlayerPrefs.SetInt("level", 0);
        LeanTween.alpha(btncontinue, 1f, 2f).setEase(LeanTweenType.easeInQuad);
        btncontinue.SetActive(false);
    }
}
