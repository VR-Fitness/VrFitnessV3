using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TurretController : MonoBehaviour
{
   

    public Transform ParentRotate;
    public Transform ChildRotate;
    
    public float speedX = 90f;
    public float speedY = 90f;
    public float maxAngleX;
    public float maxAngleY;
    public GameObject target1;

    private Quaternion ParentStartRotation;
    private Quaternion ChildStartRotation;
   

  
   
    




    // Start is called before the first frame update
    void Start()
    {
        ParentStartRotation = ParentRotate.localRotation;
        ChildStartRotation = ChildRotate.localRotation;
      
    }

    // Update is called once per frame
    void Update()
    {
       
        Turret(ParentRotate, target1, "x", ParentStartRotation, maxAngleX, speedX);
        Turret(ChildRotate, target1, "y", ChildStartRotation, maxAngleY, speedY);

       

       

    }


    

    public void Turret(Transform Object, GameObject Target, string Axis, Quaternion TurretStartRotation,float maxAngle, float speed)
    {

        //if target not found
        if (Target == null)
        {  
        }

        //if target  found
        if (Object && maxAngle != 0f && Target!= null)
        {
            float angle;
            Vector3 targetRelative;
            Quaternion targetRotation;
           
            targetRelative = Object.InverseTransformPoint(Target.transform.position);

            switch (Axis)
            {
                case "x":
                       angle = Mathf.Atan2(targetRelative.x, targetRelative.z) * Mathf.Rad2Deg;
                       targetRotation = Object.rotation * Quaternion.Euler(0f, Mathf.Clamp(angle, -speed * Time.deltaTime, speed * Time.deltaTime), 0f);
                       break;
                case "y":
                       angle = -Mathf.Atan2(targetRelative.y, targetRelative.z) * Mathf.Rad2Deg;
                       targetRotation = Object.rotation * Quaternion.Euler(Mathf.Clamp(angle, -speed * Time.deltaTime, speed * Time.deltaTime), 0f, 0f);
                       break;
                default:
                       angle = -Mathf.Atan2(targetRelative.y, targetRelative.z) * Mathf.Rad2Deg;
                       targetRotation = Object.rotation * Quaternion.Euler(Mathf.Clamp(angle, -speed * Time.deltaTime, speed * Time.deltaTime), 0f, 0f);
                       break;
            }

                    

            if (angle >= 180f)
            {
                angle = 180f - angle;
            }

            if (angle <= -180f)
            {
                angle = -180f + angle;
            }


            

            if (maxAngle < 360f && maxAngle > 0f)
            {
                Object.rotation = Quaternion.RotateTowards(Object.parent.rotation * TurretStartRotation, targetRotation, maxAngle);
            }
            else
            {
                Object.rotation = targetRotation;
            }
          
        }


    }


   
}
