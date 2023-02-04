using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Key_Collection : MonoBehaviour
{
    public AudioSource endgamesound;
    public Canvas endgameCanvas;
    public EndGame EndGame;
    public GameObject key10;

    public AudioSource keySound;
    //UPPER ROOMS
    public Animator door1;
    public Animator door2;
    public Animator door3;
    public Animator door4;

    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;

    //RIGHT ROOMS 
    public GameObject key5;
    public Animator doorR1;

    public GameObject key6;
    public Animator doorR2;

    public GameObject key7;
    public Animator doorR3;

    public GameObject key8;
    public Animator doorR4;

    //LEFT ROOMS
    public GameObject key9;
    public Animator doorL;


    //WIN STATE CHECK
    public static bool gotKey8;
    public static bool gotKey9;


    void Start()
    {
        gotKey8 = false;
        gotKey9 = false;

        endgameCanvas.enabled = false;
        EndGame.enabled = false;
        EndGame.enabled = false;
    }

  
    void Update()
    {
         
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "key_1")
        {
            door1.Play("Door_1");
            Debug.Log("KEY1");
            Destroy(key1);
            keySound.Play();
        }

        if (collision.gameObject.tag == "key_2")
        {
            door2.Play("Door_2");
            Debug.Log("KEY2");
            Destroy(key2);
            keySound.Play();
        }

        if (collision.gameObject.tag == "key_3")
        {
            door3.Play("Door_3");
            Debug.Log("KEY3");
            Destroy(key3);
            keySound.Play();
        }

        if (collision.gameObject.tag == "key_4")
        {
            door4.Play("Door_4_2");
            Debug.Log("KEY3");
            Destroy(key4);
            keySound.Play();

        }





        if (collision.gameObject.tag == "key_5")
        {
            doorR1.Play("Door_R1");
            Destroy(key5);
            keySound.Play();

        }


        if (collision.gameObject.tag == "key_6")
        {
            doorR2.Play("Door_R2");
            key6.GetComponent<SpriteRenderer>().enabled = false;
            key6.GetComponent<Collider2D>().enabled = false;
            keySound.Play();

        }


        if (collision.gameObject.tag == "key_7")
        {
            doorR3.Play("Door_R3");
            key7.GetComponent<SpriteRenderer>().enabled = false;
            key7.GetComponent<Collider2D>().enabled = false;
            keySound.Play();
        }



        if (collision.gameObject.tag == "key_8")
        {
            doorR4.Play("Door_R4");
            
            gotKey8 = true;

            key8.GetComponent<SpriteRenderer>().enabled = false;
            key8.GetComponent<Collider2D>().enabled = false;
            keySound.Play();
        }




        if (collision.gameObject.tag == "key_9")
        {
            doorL.Play("Door_L");
            Destroy(key9);
            gotKey9 = true;
            keySound.Play();
        }

        if (collision.gameObject.tag == "key_10")
        {
            Destroy(key10);
            endgameCanvas.enabled = true;
            endgamesound.Play();
            EndGame.enabled = true;
        }


    }
}
