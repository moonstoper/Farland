using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameCheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {   
            Debug.Log("Triggerd End");
            other.enabled = false;
            GameObject GameEngine = GameObject.FindGameObjectWithTag("GameEngine");
            Destroy(GameEngine);
            Debug.Log("NEXT");
            SceneManager.LoadScene(0);
            
        }   

    }
}
