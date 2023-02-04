using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartRoom : MonoBehaviour
{
    public Canvas startCanvas;
    public Canvas creditsCanvas;
    
    public Animator cameraTrans;
    public Animator startWhiteDoor;
    
    public GameObject cameraMain;

    private bool enterPressed;
  

    void Start()
    {
        cameraMain.transform.position = new Vector2(0, 15.56f);

        startCanvas.enabled = true;
        //creditsCanvas.enabled = false;

        enterPressed = false;
     
    }

   
    void Update()
    {
        //START ROOM TO UPPER ROOM
        if (Input.GetKeyDown(KeyCode.Return))
        {
            startWhiteDoor.Play("Start_Platform");
            enterPressed = true;
            Debug.Log("pressed enter");
        }

        if (enterPressed == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("already pressed enter");
            }
        }

        //START ROOM TO CREDITS ROOM
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraTrans.Play("StartRoom_to_Credits");
           

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cameraTrans.Play("Credits_to_StartRoom");
            
        }

    }

 
}
