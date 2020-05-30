using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class AddObject : MonoBehaviour
{

    public GameObject test;
   // public GameObject ship;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        test.transform.position = Player.instance.hmdTransform.position;
      //  test.transform.localRotation = Player.instance.hmdTransform.rotation;
        // test.transform.TransformDirection(Player.instance.hmdTransform.position) ;

      //  ship.transform.localRotation = Player.instance.hmdTransform.rotation;
       // ship.transform.rotation = Player.instance.hmdTransform.rotation;


    }
}
