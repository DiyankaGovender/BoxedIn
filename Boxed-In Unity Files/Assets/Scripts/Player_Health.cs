using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public AudioSource deadSound;

    public GameObject player;
    public GameObject playerhead;
    public LineRenderer playerrope;
 
    public GrapplingGun playerWhipScript;
    public Player_Movement playerMoveScript;

    public GameObject playerParticle;


    private float time = 1f;

    void Start()
    {
        player.GetComponent<Transform>();
        player.GetComponent<SpriteRenderer>();
        playerhead.GetComponent<SpriteRenderer>();

       
    }

    
    void Update()
    {
        
    }

    public void explode()
    {
        GameObject particle = Instantiate(playerParticle,transform.position, Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();
    }

    public void disablePlayer()
    {
        player.gameObject.GetComponent<SpriteRenderer>().enabled = false;

        playerhead.GetComponent<SpriteRenderer>().enabled = false;
        deadSound.Play();
        explode();

        playerrope.enabled = false;

     
    }

    public void enablePlayer()
    {
        player.gameObject.GetComponent<SpriteRenderer>().enabled = true;

        playerhead.GetComponent<SpriteRenderer>().enabled = true;

        playerrope.enabled = true;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //UPPER ROOM 1

        //UPPER ROOM 2
        if (collision.gameObject.tag == "spikes_UpperRoom2")
        {
            StartCoroutine(upperRoom2());
        }

        //UPPER ROOM 3
        if (collision.gameObject.tag == "spikes_UpperRoom3" 
            || collision.gameObject.tag== "enemy_1")
        {
            StartCoroutine(upperRoom3());
        }

        //UPPER ROOM 4
        if (collision.gameObject.tag == "spikes_UpperRoom4"
           || collision.gameObject.tag == "enemy_2")
        {
            StartCoroutine(upperRoom4());
        }

        //MAIN ROOM
        if (collision.gameObject.tag == "spikes_MainRoom")
        {
            StartCoroutine(mainRoom());
        }

        // RIGHT ROOM 1

        //RIGHT ROOM 2
        if (collision.gameObject.tag == "spikes_RightRoom2"
            ||  collision.gameObject.tag =="enemy_3"
            ||  collision.gameObject.tag == "enemy_4"
            ||  collision.gameObject.tag == "enemy_5")
        {
            StartCoroutine(RightRoom2());
        }

        //RIGHT ROOM 3
        if (collision.gameObject.tag == "spikes_RightRoom3"
            || collision.gameObject.tag == "enemy_6"
            || collision.gameObject.tag == "enemy_7")
        {
            StartCoroutine(RightRoom3());
        }

        //RIGHT ROOM 4
        if (collision.gameObject.tag == "spikes_RightRoom4"
           || collision.gameObject.tag == "enemy_8"
           || collision.gameObject.tag == "enemy_9"
           || collision.gameObject.tag == "enemy_10")
        {
            StartCoroutine(RightRoom4());
        }


        //LEFT ROOMS
        if (collision.gameObject.tag == "spikes_LeftRoom")
        {
            StartCoroutine(LeftRoom());
        }

    }



    public IEnumerator upperRoom2()
    {

        disablePlayer();   

        yield return new WaitForSeconds(time);

        player.transform.position = new Vector2(14.84f, 6.74f);

        enablePlayer();

       
    }


    public IEnumerator upperRoom3()
    {

        disablePlayer();

        yield return new WaitForSeconds(time);

        player.transform.position = new Vector2(40.82f, -10.08f);

        enablePlayer();
    }


    public IEnumerator upperRoom4()
    {

        disablePlayer();

        yield return new WaitForSeconds(time);

        player.transform.position = new Vector2(11.16f, -11.78f);

        enablePlayer();
    }



    public IEnumerator mainRoom()
    {

        disablePlayer();

        yield return new WaitForSeconds(time);

        player.transform.position = new Vector2(-15.17f, -28.2f);

        enablePlayer();
    }



    public IEnumerator RightRoom2()
    {

        disablePlayer();

        yield return new WaitForSeconds(time);

        player.transform.position = new Vector2(69.3f, -26.4f);

        enablePlayer();
    }

    public IEnumerator RightRoom3()
    {

        disablePlayer();

        yield return new WaitForSeconds(time);

        player.transform.position = new Vector2(94.3f, -41.6f);

        enablePlayer();
    }



    public IEnumerator RightRoom4()
    {

        disablePlayer();

        yield return new WaitForSeconds(time);

        player.transform.position = new Vector2(66.3f, -54.3f);

        enablePlayer();
    }


    public IEnumerator LeftRoom()
    {

        disablePlayer();

        yield return new WaitForSeconds(time);

        player.transform.position = new Vector2(-19.4f, -52.76f);

        enablePlayer();
    }
}
