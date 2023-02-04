using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
  
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            collision.transform.SetParent(null);
        }
    }
}
