using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Checker : MonoBehaviour
{

    public GameObject lastarrow1;
    public GameObject lastarrow2;
    public static bool rightRoom2allEnemiesDead;
    public static bool rightRoom3allEnemiesDead;

    public GameObject key_6;
    public GameObject key_7;

    public GameObject boxRightRoom4;
    public GameObject key_8;


    //LEFT ROOM
    public GameObject switchL1Platform;
    public GameObject switchL2Platform;
    public GameObject switchL3Platform;
    public GameObject switchL4Platform;

    public GameObject keyBoxLeft;

    public static bool isALLSwitchLeft;


    //MAIN ROOM VANISHING OBJECT
    public GameObject spikesMainRoom;
    public GameObject arrows;

    public GameObject switchMain1;
    public GameObject switchMain2;
    public GameObject mainPlatform;

    void Start()
    {
        lastarrow1.SetActive(false);
        lastarrow2.SetActive(false);

        key_6.SetActive(false);
        key_7.SetActive(false);

        key_8.SetActive(false);
        boxRightRoom4.SetActive(false);

        switchL1Platform.SetActive(false);
        switchL2Platform.SetActive(false);
        switchL3Platform.SetActive(false);
        switchL4Platform.SetActive(false);

        
        isALLSwitchLeft = false;

        keyBoxLeft.SetActive(true);
    }

   
    void Update()
    {
        check();

        //LEFT ROOM
        if (Switch.isSwitchL1 ==true)
        {
            switchL1Platform.SetActive(true);
        }

        if (Switch.isSwitchL2 == true)
        {
            switchL2Platform.SetActive(true);
        }

        if (Switch.isSwitchL3 == true)
        {
            switchL3Platform.SetActive(true);
        }

        if (Switch.isSwitchL4 == true)
        {
            switchL4Platform.SetActive(true);
        }

        if(Switch.isSwitchL1==true && Switch.isSwitchL2 == true && Switch.isSwitchL3 == true && Switch.isSwitchL4 == true)
        {
            isALLSwitchLeft = true;

        }

        if (isALLSwitchLeft == true)
        {
            keyBoxLeft.SetActive(false);
        }




        //FINAL ROOM CHECK
        if (Player_Key_Collection.gotKey8==true && Player_Key_Collection.gotKey9==true) 
        {
            spikesMainRoom.SetActive(false);
            arrows.SetActive(false);
            lastarrow1.SetActive(true);
            lastarrow2.SetActive(true);
            switchMain1.SetActive(false);
            switchMain2.SetActive(false);
            mainPlatform.SetActive(false);
        }
    }

    public void check()
    {
        if (Walking_Enemy.enemy3Dead && Walking_Enemy.enemy4Dead && Walking_Enemy.enemy5Dead)
        {

            rightRoom2allEnemiesDead = true;
            key_6.SetActive(true);


        }

        if (Walking_Enemy.enemy6Dead && Walking_Enemy.enemy7Dead)
        {
            key_7.SetActive(true);

        }

        if (Walking_Enemy.enemy8Dead && Walking_Enemy.enemy9Dead && Walking_Enemy.enemy10Dead)
        {
            key_8.SetActive(true);
            boxRightRoom4.SetActive(true);
            
        }
    }
}
