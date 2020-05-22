using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Pointer : MonoBehaviour
{
  //  public SteamVR_Action_Boolean fireAction;
   // public SteamVR_Action_Boolean ShieldAction;
    public float Distance = 2.0f;
    public GameObject mDot;


    /*public GameObject turret;
    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    public GameObject Shield;
    */

   // private bool fire = false;
   // private float shootDelay = 0;
    private LineRenderer lineRenderer = null;
    //private SteamVR_Behaviour_Pose pose;


    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

       // pose = GetComponentInParent<SteamVR_Behaviour_Pose>();
    }
   
    // Update is called once per frame
    void Update()
    {
        UpdateLine();


       
        // set dummy target point for turret
      //  turret.GetComponent<TurretController>().target1 = mDot;

       

        /*
        // tjeck trigger state and set bool
        if (fireAction.stateDown) fire = true;   
        if (fireAction.stateUp) fire = false;

        // fire method of true;
        Fire(fire);


        //shield mechanic Work in progress
        if (ShieldAction.GetStateDown(pose.inputSource))
        {
            Shield.SetActive(true);
        }
        else if(ShieldAction.GetStateUp(pose.inputSource))
        {
            Shield.SetActive(false);
        }
        */

    }


    //create line for target pointer
    private void UpdateLine()
    {
        float targetLength = Distance;
        RaycastHit hit = CreateRayCast(targetLength);      
        Vector3 endPosition = transform.position + (transform.forward * targetLength);

        if (hit.collider != null)
        {
            endPosition = hit.point;
        }

        mDot.transform.position = endPosition;
        lineRenderer.SetPosition(0,transform.position);
        lineRenderer.SetPosition(1, endPosition);
    }



    private RaycastHit CreateRayCast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, Distance);

        return hit;
    }


    /*
    // shoot projectile
    public void Fire(bool fire)
    {
        shootDelay += Time.deltaTime;

        if (fire && shootDelay >= 0.2f) // if true and timer exceeded
        {
            Rigidbody bulletRb = Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            bulletRb.velocity = bulletSpawnPoint.transform.forward * 50.0f;
            shootDelay = 0;
        }       
    }
    */
}
