using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite switchOnImage;
    public Sprite switchOffImage;

    //UPPER ROOMS
    public Animator door4_1;

    //MAIN ROOMS 
    public Animator mainRoomWhiteDoor1;
    public Animator mainRoomWhiteDoor2;

    //RIGHT ROOMS
    public Animator rightRoom2WhiteDoor;
    public Animator rightRoom4WhiteDoor;
    

    //public GameObject Spikes1_Room4;
   

    //LEFT ROOMS
    public static bool isSwitchL1;
    public static bool isSwitchL2;
    public static bool isSwitchL3;
    public static bool isSwitchL4;
   

    void Start()
    {
        isSwitchL1 = false;
        isSwitchL2 = false;
        isSwitchL3 = false;
        isSwitchL4 = false;
        
    }

    
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ROOM 4
        if (collision.gameObject.tag == "player" && this.gameObject.tag=="switch_room4")
        {

            Debug.Log("switch room 4");
            
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.spriteRenderer.sprite = switchOnImage;
            
            door4_1.Play("Door_4_1");
        
           
            
        }

        //MAIN ROOM 1
        if (collision.gameObject.tag == "player" && this.gameObject.tag == "switch_main1")
        {
            
            Debug.Log("SwitchMain1");

            this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.spriteRenderer.sprite = switchOnImage;

            mainRoomWhiteDoor1.Play("Door_White_MainRoom1");

        }
        //MAIN ROOM 2
        if (collision.gameObject.tag == "player" && this.gameObject.tag == "switch_main2")
        {

            Debug.Log("SwitchMain2");

            this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.spriteRenderer.sprite = switchOnImage;

            mainRoomWhiteDoor2.Play("Door_White_MainRoom2");
        }

        //RIGHT ROOM 2 
        if (collision.gameObject.tag == "player" && this.gameObject.tag == "switch_R2")
        {

            this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.spriteRenderer.sprite = switchOnImage;

            rightRoom2WhiteDoor.Play("Door_White_RightRoom2");
        }


        //RIGHT ROOM 4
        if (collision.gameObject.tag == "player" && this.gameObject.tag == "switch_R4")
        {

            this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.spriteRenderer.sprite = switchOnImage;

            rightRoom4WhiteDoor.Play("Door_White_RightRoom4");
        }




        //LEFT ROOM
        if (collision.gameObject.tag == "player" && this.gameObject.tag == "switch_L1")
        {

            this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.spriteRenderer.sprite = switchOnImage;

            isSwitchL1 = true;
            StartCoroutine(switchTime());
        }


        if (collision.gameObject.tag == "player" && this.gameObject.tag == "switch_L2")
        {

            this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.spriteRenderer.sprite = switchOnImage;
            isSwitchL2 = true;

            StartCoroutine(switchTime());
        }

        if (collision.gameObject.tag == "player" && this.gameObject.tag == "switch_L3")
        {

            this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.spriteRenderer.sprite = switchOnImage;

            isSwitchL3 = true;

            StartCoroutine(switchTime());
        }

        if (collision.gameObject.tag == "player" && this.gameObject.tag == "switch_L4")
        {

            this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.spriteRenderer.sprite = switchOnImage;

            isSwitchL4 = true;

            StartCoroutine(switchTime());
        }

        

    }

    public IEnumerator switchTime()
    {
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

   
}
