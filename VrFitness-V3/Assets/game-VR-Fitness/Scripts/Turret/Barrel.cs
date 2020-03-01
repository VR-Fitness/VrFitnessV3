using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{


    public Transform target;
    public float speed = 60;
    public float maxAngle;
    public float minAngle;
    public string rotateAxis = "x";



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 test = GetTargetDir("",1);

       
        

        if ((Quaternion.LookRotation(test).eulerAngles.x <= maxAngle) || (Quaternion.LookRotation(test).eulerAngles.x >= 360 - minAngle && Quaternion.LookRotation(test).eulerAngles.x <= 360))
        {

            test.x = 0;
            this.gameObject.transform.rotation = Quaternion.LookRotation(test);
        }

    }


    private Vector3 GetTargetDir(string axis, float speed)
    {
        float step = speed * Time.deltaTime;
        Vector3 targetDir = (target.position - transform.position);
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);




        switch (axis)
        {
            case "x":
                newDir.y = 0;
                return newDir;
            case "y":
                newDir.x = 0;
                return newDir;
            default:

                return newDir;
        }

    }
}
