using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public GameObject Player;
    public Camera maincam;

    public float speedoffset;
    public Vector2 positionoffset;
    void Start()
    {
        maincam.GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 startpos = maincam.transform.position;
        Vector3 endpos = Player.transform.position;


        endpos.x += positionoffset.x;
        endpos.y += positionoffset.y;
        endpos.z = -20;

        maincam.transform.position = Vector3.Lerp(startpos, endpos, speedoffset * Time.deltaTime);



    }
}