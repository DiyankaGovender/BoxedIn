using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrapplingGun : MonoBehaviour
{
    
    public GrappleRope grappleRope;

    public int interactableLayer = 9;

    public GameObject playerGameObject;
    public Camera mainCamera;


    public Transform player;
    public Transform whipPivot;
    public Transform whipFirePoint;


    public bool playerRotation;
    [Range(0, 90)] public float playerRotationSpeed;


    public bool hasMaxHookDistance;
    public float maxHookDistance = 15;


    public bool launchToHookPoint;

    public bool canLaunch;
    [Range(0, 5)] public float launchSpeed = 5;


    public bool autoHookDistance;
    public float hookTargetDistance = 3;
    public float hookTargetFrequency = 3;


    public SpringJoint2D playerSpringJoint;

    [HideInInspector] public Vector2 hookPoint;
    [HideInInspector] public Vector2 hookDistance;
    Vector2 mouseFirePointDistance;


   //SWITCH
   public Switch switchGameObject;

    private void Start()
    {
        grappleRope.enabled = false;
        playerSpringJoint.enabled = false;

        playerRotation = true;
        hasMaxHookDistance = true;
        launchToHookPoint = true;
        canLaunch = true;
        autoHookDistance = false;

        //maxHookDistance = 5;
        playerRotationSpeed = 5f;

       
    }

    private void Update()
    {
        mouseFirePointDistance = mainCamera.ScreenToWorldPoint(Input.mousePosition) - whipPivot.position;

        //LEFT MOUSE CLICK = PLAYER PULLED TOWARDS OBJECT 
        if (Input.GetMouseButtonDown(0))
        {
            
            SetHookPoint();
        }
        
        
        if (Input.GetMouseButton(0))
        {
            if (grappleRope.enabled)
            {
                RotateGun(hookPoint, false);
            }
            else
            {
                RotateGun(mainCamera.ScreenToWorldPoint(Input.mousePosition), false);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            grappleRope.enabled = false;
            playerSpringJoint.enabled = false;
            playerSpringJoint.connectedBody = null;

        }
        else
        {
            RotateGun(mainCamera.ScreenToWorldPoint(Input.mousePosition), true);
        }



      



    }

    //PLAYER LOOKS AROUND
    void RotateGun(Vector3 lookPoint, bool allowPlayerRotation)
    {
        Vector3 distanceVector = lookPoint - whipPivot.position;

        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        if (playerRotation == true && allowPlayerRotation)
        {
            Quaternion startRotation = whipPivot.rotation;
            whipPivot.rotation = Quaternion.Lerp(startRotation, Quaternion.AngleAxis(angle, Vector3.forward), 
                Time.deltaTime * playerRotationSpeed);
        }
        else
            whipPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }


    //LEFT CLICK SET POINT TO HOOK PLAYER TO OBJECT
    void SetHookPoint()
    {
        if (Physics2D.Raycast(whipFirePoint.position, mouseFirePointDistance.normalized))
        {
            RaycastHit2D hitObject = Physics2D.Raycast(whipFirePoint.position, mouseFirePointDistance.normalized);
            if ((hitObject.transform.gameObject.layer == interactableLayer

                ) && ((Vector2.Distance(hitObject.point, whipFirePoint.position) <= maxHookDistance) || hasMaxHookDistance == false))
            {
                hookPoint = hitObject.point;//IF PULL OBJECT TOWARDS PLAYER IS IT PUBLIC TRANSFORM OF OBJECT = PLAYERRAYCAST.POINT?
                playerSpringJoint.connectedBody = hitObject.rigidbody;
                hookDistance = hookPoint - (Vector2)whipPivot.position;
                grappleRope.enabled = true;

            }
           




        }
    }

    
    

    //DETERMINES IF LINE CAN BE DRAWN IN THE ROPE SCRIPT 
    public void Hook()
    {

        if (launchToHookPoint == false && autoHookDistance == false)
        {
            playerSpringJoint.distance = hookTargetDistance;
            playerSpringJoint.frequency = hookTargetFrequency;
        }

        if (launchToHookPoint == false)
        {
            if (autoHookDistance == true)
            {
                playerSpringJoint.autoConfigureDistance = true;
                playerSpringJoint.frequency = 0;
            }
            playerSpringJoint.connectedAnchor = hookPoint;
            playerSpringJoint.enabled = true;
        }

       else
        {

           if (canLaunch == true)
            {
               playerSpringJoint.connectedAnchor = hookPoint;
               playerSpringJoint.distance = 0;
               playerSpringJoint.frequency = launchSpeed;
               playerSpringJoint.enabled = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (hasMaxHookDistance)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(whipFirePoint.position, maxHookDistance);
        }
    }




}

