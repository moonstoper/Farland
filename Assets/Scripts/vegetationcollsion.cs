using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vegetationcollsion : MonoBehaviour
{
    Color _color;
    public void Start()
    {
        _color = GetComponent<SpriteRenderer>().color;
        Debug.Log(_color);


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Color color = _color;
            color.a = .5f;
            GetComponentInChildren<SpriteRenderer>().color = color;
            Debug.Log("Plants");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GetComponentInChildren<SpriteRenderer>().color = _color;
    }
}
