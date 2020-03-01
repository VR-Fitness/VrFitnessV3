using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Shoot : MonoBehaviour
{
  
    public SteamVR_Action_Boolean fireAction;
    public SteamVR_Action_Boolean ShieldAction;
    public GameObject turret;
    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    public GameObject Shield;
    public GameObject mDot;

    private bool fire = false;
    private float shootDelay = 0;
    private SteamVR_Behaviour_Pose pose;
    private Hand hand;



    private void Awake()
    {
        
        pose = GetComponentInParent<SteamVR_Behaviour_Pose>();
        hand = GetComponentInParent<Hand>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // set dummy target point for turret
        turret.GetComponent<TurretController>().target1 = mDot;

       
        
    }

    // Update is called once per frame
    void Update()
    {
        // tjeck trigger state and set bool
        if (fireAction.GetStateDown(pose.inputSource))
        {

            
            fire = true;         
        }
       
        if (fireAction.GetStateUp(pose.inputSource))
        {
           
            fire = false;           
        }
            

        // fire method of true;
        Fire(fire);

        /*
        //shield mechanic Work in progress
        if (ShieldAction.GetStateDown(pose.inputSource))
        {
            Shield.SetActive(true);
        }
        else if (ShieldAction.GetStateUp(pose.inputSource))
        {
            Shield.SetActive(false);
        }
        */
    }


    // shoot projectile
    public void Fire(bool fire)
    {
        shootDelay += Time.deltaTime;

        if (fire && shootDelay >= 0.2f) // if true and timer exceeded
        {
            hand.hapticAction.Execute(0, 0.2f, 1, 0.5f, pose.inputSource );// controller vibration
           
            Rigidbody bulletRb = Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            bulletRb.velocity = bulletSpawnPoint.transform.forward * 50.0f;
            shootDelay = 0;
        }
    }
}
