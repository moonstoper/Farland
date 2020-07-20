using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toNextLevel : MonoBehaviour
{
    // Start is called before the first frame update
     ParticleSystem ParticleSystem;
     
    void Start()
    {
        ParticleSystem = GetComponent<ParticleSystem>();
        ParticleSystem.Stop();
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
        Debug.Log("Entered");
        StartCoroutine("ToNext");
        }
    }
    
    IEnumerator ToNext()
    {   GameObject Player = GameObject.FindGameObjectWithTag("Player");
        GameObject GameEngine = GameObject.FindGameObjectWithTag("GameEngine");
        Player.GetComponent<PlayerMovemnt>().enabled = false;
        yield return new  WaitForSeconds(3f);
        ParticleSystem.Stop();
        PlayerPrefs.SetInt("isNextLevel", 1);
        Destroy(GameEngine);
        SceneManager.LoadScene("level2");
    }
}
