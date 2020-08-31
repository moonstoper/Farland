using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerPref : MonoBehaviour
{
    // Start is called before the first frame update

    private GameEngine gameEngine;

    public int level;
    public Vector2 lastposition;
    public float xaxis, yaxis;
    public int health;

    

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
        Vector2 chkpoint = FindObjectOfType<GameEngine>().lastcheckpoint;
        xaxis = chkpoint.x;
        yaxis = chkpoint.y;
        PlayerPrefs.SetFloat("xaxis", xaxis);
        PlayerPrefs.SetFloat("yaxis", yaxis);
        level = (int)SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("level", (int)SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("isNewGame", 0);
        PlayerPrefs.Save();
        Debug.Log("Saved");
    }

}
