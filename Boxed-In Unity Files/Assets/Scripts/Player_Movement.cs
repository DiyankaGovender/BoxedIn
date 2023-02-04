using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D player;
    public SpriteRenderer spriterend;

    public float moveSpeedRight = 15;
    public float moveSpeedLeft = -15;
  





    void Start()
    {
        player.GetComponent<Rigidbody2D>();
 

    }



    void Update()
    {
        //Player Presses A/Left Arrown Down = MOVE LEFT
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.velocity = new Vector3(moveSpeedLeft, player.velocity.y, 0f);


            spriterend.flipX = true;
        }

        //Player Stops Pressing A/Left Arrow Down = STOP MOVING
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            player.velocity = new Vector3(0f, player.velocity.y, 0f);



        }



        //Player Presses D/Right Arrown Down = MOVE RIGHT
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.velocity = new Vector3(moveSpeedRight, player.velocity.y, 0f);


            spriterend.flipX = false;
        }

        //Player Stops Pressing D/Right Arrow Down = STOP MOVING
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            player.velocity = new Vector3(0f, player.velocity.y, 0f);


        }

    }

}
