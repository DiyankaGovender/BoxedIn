using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Level_Change : MonoBehaviour
{
    public GameObject Block_LeftRoom;
    public GameObject maintoRightblock;
    public GameObject whiteMainBlock;
    public GameObject endPLatform;
    public StartRoom startroom;
    public GameObject apperingplatformVanish;

  

    public float blocktime = 6f;

   

    public Animator cameraTransition;
    public GrapplingGun grapplingGun;

    public GameObject upperRoom1_Trigger;
    public GameObject upperRoom1;

    public GameObject upperRoom2_Trigger;
    public GameObject upperRoom2;

    public GameObject upperRoom3_Trigger;
    public GameObject upperRoom3;

    public GameObject upperRoom4_Trigger;


    public GameObject mainRoom1_Trigger;
    public GameObject MainRoom1;

    public GameObject mainRoom2_Trigger;
    public GameObject MainRoom2;

    public GameObject rightRoom1_Trigger;
    public GameObject rightRoom1;


    public GameObject rightRoom2_Trigger;
    public GameObject rightRoom2;

    public GameObject rightRoom3_Trigger;
    public GameObject rightRoom3;

    public GameObject rightRoom4_Trigger;
    public GameObject rightRoom4;


    public GameObject leftRoom_Trigger;
 

    public GameObject lowerRoom_Trigger;
    public GameObject lowerPlatform;

    public GameObject mainPlatform;
    void Start()
    {
        Block_LeftRoom.SetActive(false);
        maintoRightblock.SetActive(false);
        whiteMainBlock.SetActive(false);
        endPLatform.SetActive(false);
        upperRoom1.SetActive(false);
        upperRoom2.SetActive(false);
        upperRoom3.SetActive(false);


        rightRoom1.SetActive(false);
        rightRoom2.SetActive(false);
        rightRoom3.SetActive(false);
        rightRoom4.SetActive(false);

        MainRoom1.SetActive(false);
        MainRoom2.SetActive(false);

    

        lowerPlatform.SetActive(false);

      
        apperingplatformVanish.SetActive(false);

        grapplingGun.maxHookDistance = 20;
    }


    void Update()
    {

    }

    public IEnumerator lefttoMain()
    {
        yield return new WaitForSeconds(4f);
        Block_LeftRoom.SetActive(true);
    }

    public IEnumerator endPlatform()
    {
        yield return new WaitForSeconds(4f);
        endPLatform.SetActive(true);
    }

    public IEnumerator maintoright()
    {
        yield return new WaitForSeconds(4f);
        maintoRightblock.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //START ROOM
        if (collision.gameObject.tag == "start_room")
        {
            cameraTransition.Play("StartRoom_to_Upper1");
            startroom.enabled = false;
            grapplingGun.maxHookDistance = 5;
            StartCoroutine(endPlatform());
        }


        //LEFT  ROOMS 


        if (collision.gameObject.tag == "room_L")
        {

            cameraTransition.Play("Left_to_MainRoom");
            grapplingGun.maxHookDistance = 38;
            Destroy(mainRoom2_Trigger);
            //Destroy(mainPlatform);
            mainPlatform.SetActive(false);
            StartCoroutine(lefttoMain());

        }

        //UPPER ROOMS 
        if (collision.gameObject.tag == "room_1")
        {
            Debug.Log("ROOM1");
            cameraTransition.Play("Room1_to_2");
            Destroy(upperRoom1_Trigger);

            StartCoroutine(UpperRoom1times());

        }

        if (collision.gameObject.tag == "room_2")
        {
            Debug.Log("ROOM2");
            cameraTransition.Play("Room2_to_3");
            Destroy(upperRoom2_Trigger);

            StartCoroutine(UpperRoom2times());
        }

        if (collision.gameObject.tag == "room_3")
        {
            Debug.Log("ROOM3");
            cameraTransition.Play("Room3_to_4");
            Destroy(upperRoom3_Trigger);

            StartCoroutine(UpperRoom3times());
        }

        if (collision.gameObject.tag == "room_4")
        {
            //StartCoroutine(timetoptomain());


            StartCoroutine(UpperRoom4times());
        }

        //MAIN ROOM
        if (collision.gameObject.tag == "mainRoom_1")
        {
            cameraTransition.Play("RoomMain_to_Right1");
            grapplingGun.maxHookDistance = 10;
            Destroy(mainRoom1_Trigger);
            StartCoroutine(maintoright());
            //StartCoroutine(MainRoom1times());
        }

        //LEFT ROOM
        if (collision.gameObject.tag == "mainRoom_2")
        {
            cameraTransition.Play("RoomMain_to_Left");
            grapplingGun.maxHookDistance = 38;
            Destroy(mainRoom2_Trigger);

            StartCoroutine(maintoleftroom());
        }




        //RIGHT ROOMS
        if (collision.gameObject.tag == "room_R1")
        {
            cameraTransition.Play("RoomRight1_to_2");
            Destroy(rightRoom1_Trigger);

            StartCoroutine(RightRoom1times());
        }

        if (collision.gameObject.tag == "room_R2")
        {
            cameraTransition.Play("RoomRight2_to_3");
            Destroy(rightRoom2_Trigger);

            StartCoroutine(RightRoom2times());
        }

        if (collision.gameObject.tag == "room_R3")
        {
            cameraTransition.Play("RoomRight3_to_4");
            Destroy(rightRoom3_Trigger);

            StartCoroutine(RightRoom3times());
        }


        if (collision.gameObject.tag == "room_R4")
        {
            cameraTransition.Play("RoomRight4_to_Main");
            grapplingGun.maxHookDistance = 38;
            Destroy(rightRoom4_Trigger);

            StartCoroutine(RightRoom4times());
        }

        if (collision.gameObject.tag == "room_Lower")
        {
            Destroy(lowerRoom_Trigger);
            grapplingGun.maxHookDistance = 60;

            StartCoroutine(lower());


        }
    }




    //MAIN ROOM
    public IEnumerator UpperRoom4times()
    {
        cameraTransition.Play("Room4_to_Transition_to_Main");
        grapplingGun.maxHookDistance = 38;
        yield return new WaitForSeconds(5f);
        Debug.Log("ROOM4");
       
        Destroy(upperRoom4_Trigger);
        whiteMainBlock.SetActive(true);

    }

    //LOWER ROOM
    public IEnumerator lower()
    {
        cameraTransition.Play("RoomMain_to_LowerRoom");
        yield return new WaitForSeconds(1);
        lowerPlatform.SetActive(true);
        
        apperingplatformVanish.SetActive(true);
    }





    public IEnumerator UpperRoom1times()
    {
        yield return new WaitForSeconds(4f);
        upperRoom1.SetActive(true);
    }

    public IEnumerator UpperRoom2times()
    {
        yield return new WaitForSeconds(4f);
        upperRoom2.SetActive(true);
    }

    public IEnumerator UpperRoom3times()
    {
        yield return new WaitForSeconds(4f);
        upperRoom3.SetActive(true);
    }




    public IEnumerator MainRoom1times()
    {
        yield return new WaitForSeconds(4f);
        MainRoom1.SetActive(true);
    }

    public IEnumerator MainRoom2times()
    {
        yield return new WaitForSeconds(4f);
        MainRoom2.SetActive(true);
    }


    public IEnumerator RightRoom1times()
    {
        yield return new WaitForSeconds(4f);
        rightRoom1.SetActive(true);
    }


    public IEnumerator RightRoom2times()
    {
        yield return new WaitForSeconds(4f);
        rightRoom2.SetActive(true);
    }

    public IEnumerator RightRoom3times()
    {
        yield return new WaitForSeconds(4f);
        rightRoom3.SetActive(true);
    }

    public IEnumerator RightRoom4times()
    {
        yield return new WaitForSeconds(4f);
        rightRoom4.SetActive(true);
    }

    

    public IEnumerator maintoleftroom()
    {
        yield return new WaitForSeconds(4f);
        MainRoom2.SetActive(true);
    }
}
