using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MenuHelper : MonoBehaviour
{   
    public GameObject btn;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Start()
    {
        int level  = PlayerPrefs.GetInt("level", 0);
        btn.SetActive(level > 0);
        LeanTween.alpha(btn, 0f, 2f).setEase(LeanTweenType.easeOutQuad);
        Debug.Log(btn);
        
    }
}
