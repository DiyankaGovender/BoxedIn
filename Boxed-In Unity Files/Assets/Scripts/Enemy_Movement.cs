using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float enemySpeed =2;
    public bool isMovingRight;
    
    void Start()
    {
        
    }

  
    void Update()
    {
        if(isMovingRight == true)
        {
            transform.Translate(2 * Time.deltaTime * enemySpeed, 0, 0);
            
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * enemySpeed, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "triggerbox")
        {
            if (isMovingRight == true)
            {
                isMovingRight = false;
            }
            
            else
            {
                isMovingRight = true;
            }
        }
    }
}
