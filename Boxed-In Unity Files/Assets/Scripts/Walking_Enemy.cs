using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Walking_Enemy : MonoBehaviour
{
    public AudioSource enemydeadsound;
    public Canvas boxcanvas;
    //UPPER ROOMS
    //ROOM 3
    public GameObject Key_3;
    public GameObject Moving_Platform_Room3;

    //ROOM 4 
    public GameObject Box_Room4;
    public GameObject spikesUpperRoom4;

    //RIGHT ROOM
    public GameObject RightRoom4Spikes;
   

    

   


  


    //ENEMY BOOLS
    public static bool enemy3Dead;
    public static bool enemy4Dead;
    public static bool enemy5Dead;
    public static bool enemy6Dead;
    public static bool enemy7Dead;
    public static bool enemy8Dead;
    public static bool enemy9Dead;
    public static bool enemy10Dead;

    void Start()
    {
        boxcanvas.enabled = false;
        Key_3.SetActive(false);
        Moving_Platform_Room3.SetActive(false);
        Box_Room4.SetActive(false);
       
       
       

        enemy3Dead = false;
        enemy4Dead = false;
        enemy5Dead = false;
        enemy6Dead = false;
        enemy7Dead = false;
        enemy8Dead = false;
        enemy9Dead = false;
        enemy10Dead = false;

    }

    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        //UPPER ROOM 3
        if (collision.gameObject.tag == "spikes_UpperRoom3" && this.gameObject.tag=="enemy_1")
        {
            Debug.Log("Upper Room 3 Enemy Dead");
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.GetComponent<BoxCollider2D>());
            Destroy(this.GetComponent<PolygonCollider2D>());
            Key_3.SetActive(true);
            Moving_Platform_Room3.SetActive(true);

            enemydeadsound.Play();
        }


        //UPPER ROOM 4
        if (collision.gameObject.tag == "spikes_UpperRoom4" && this.gameObject.tag == "enemy_2")
        {
            boxcanvas.enabled = true;
            Debug.Log("Upper Room 4 Enemy Dead");
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.GetComponent<BoxCollider2D>());
            Destroy(this.GetComponent<PolygonCollider2D>());
            Box_Room4.SetActive(true);
            Destroy(spikesUpperRoom4);

            enemydeadsound.Play();
        }

        //RIGHT ROOM 2  (x3 ENEMIES)
        if (collision.gameObject.tag == "spikes_RightRoom2" && this.gameObject.tag == "enemy_3")
        {
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.GetComponent<BoxCollider2D>());
            Destroy(this.GetComponent<PolygonCollider2D>());

            enemy3Dead = true;

            enemydeadsound.Play();

        }

        if (collision.gameObject.tag == "spikes_RightRoom2" && this.gameObject.tag == "enemy_4")
        {
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.GetComponent<BoxCollider2D>());
            Destroy(this.GetComponent<PolygonCollider2D>());

            enemy4Dead = true;

            enemydeadsound.Play();
        }


        if (collision.gameObject.tag == "spikes_RightRoom2" && this.gameObject.tag == "enemy_5")
        {
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.GetComponent<BoxCollider2D>());
            Destroy(this.GetComponent<PolygonCollider2D>());

            enemy5Dead = true;

            enemydeadsound.Play();
        }















        //RIGHT ROOM 3
        if (collision.gameObject.tag == "spikes_RightRoom3" && this.gameObject.tag == "enemy_6")
        {
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.GetComponent<BoxCollider2D>());
            Destroy(this.GetComponent<PolygonCollider2D>());

            enemy6Dead = true;

            enemydeadsound.Play();

        }
        if (collision.gameObject.tag == "spikes_RightRoom3" && this.gameObject.tag == "enemy_7")
        {
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.GetComponent<BoxCollider2D>());
            Destroy(this.GetComponent<PolygonCollider2D>());

            enemy7Dead = true;

            enemydeadsound.Play();
        }















        //RIGHT ROOM 4
        if (collision.gameObject.tag == "spikes_RightRoom4" && this.gameObject.tag == "enemy_8")
        {
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.GetComponent<BoxCollider2D>());
            Destroy(this.GetComponent<PolygonCollider2D>());

            enemy8Dead = true;

            enemydeadsound.Play();
        }


        if (collision.gameObject.tag == "spikes_RightRoom4" && this.gameObject.tag == "enemy_9")
        {
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.GetComponent<BoxCollider2D>());
            Destroy(this.GetComponent<PolygonCollider2D>());

            enemy9Dead = true;

            enemydeadsound.Play();
        }


        if (collision.gameObject.tag == "spikes_RightRoom4" && this.gameObject.tag == "enemy_10")
        {
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.GetComponent<BoxCollider2D>());
            Destroy(this.GetComponent<PolygonCollider2D>());

            enemy10Dead = true;

            enemydeadsound.Play();
        }



   
    }
}
