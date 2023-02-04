using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Outline : MonoBehaviour
{
    //UPPER ROOMS
    public GameObject keyBoxRoom4;
    public GameObject hiddenPlatformsRoom4;
    public Animator Door2_White_RightRoom4;

    //RIGHT ROOMS 
    public GameObject keyBoxRoomRight1;
    public Animator whiteDoor1RightRoom3;
    public Animator whiteDoor2RightRoom3;
    public GameObject keyBoxRightRoom4;
    public GameObject movingplatformR3;

    void Start()
    {
        keyBoxRoom4.SetActive(true);
        keyBoxRoomRight1.SetActive(true);
        hiddenPlatformsRoom4.SetActive(false);
        keyBoxRightRoom4.SetActive(true);
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "box_room4" && this.gameObject.tag=="box_outline1")

        {
            keyBoxRoom4.SetActive(false);
            hiddenPlatformsRoom4.SetActive(true);
            Door2_White_RightRoom4.Play("Door2_White_RightRoom4");
        }

        //ROOM RIGHT 1
        if (collision.gameObject.tag == "box_roomR1" && this.gameObject.tag == "box_outline2")

        {
            keyBoxRoomRight1.SetActive(false);

        }

        //ROOM RIGHT 3
        if (collision.gameObject.tag == "box_roomR3" && this.gameObject.tag == "box_outline3")

        {
            whiteDoor1RightRoom3.Play("Door_White1_RightRoom3");
            movingplatformR3.SetActive(false);

        }

        if (collision.gameObject.tag == "box_roomR3" && this.gameObject.tag == "box_outline4")

        {
            whiteDoor2RightRoom3.Play("Door_White2_RightRoom3");

        }

        //ROOM RIGHT 4
        if (collision.gameObject.tag == "box_roomR4" && this.gameObject.tag == "box_outline5")

        {
            keyBoxRightRoom4.SetActive(false);

        }

    }



   
}
