using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TurretBehavior : MonoBehaviour
{
 public Transform yawSegment;
 public Transform pitchSegment;
 float yawSpeed = 30f;
 float pitchSpeed  = 30f;
 float yawLimit  = 90f;
 float pitchLimit = 90f;  private Vector3 target ;
    private Quaternion yawSegmentStartRotation ;
    private Quaternion pitchSegmentStartRotation ;



    // Start is called before the first frame update
    void Start()
    {
        yawSegmentStartRotation = yawSegment.localRotation;
        pitchSegmentStartRotation = pitchSegment.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float angle ;
        Vector3 targetRelative ;
        Quaternion targetRotation ;
        GameObject tt = GameObject.Find("target");
       
        Vector3 targetDir = (tt.transform.position - transform.position);
        target = targetDir;

        if (yawSegment && yawLimit != 0f)
        {
            targetRelative = yawSegment.InverseTransformPoint(tt.transform.position);
            angle = Mathf.Atan2(targetRelative.x, targetRelative.z) * Mathf.Rad2Deg;
            if (angle >= 180f) angle = 180f - angle; if (angle <= -180f) angle = -180f + angle;
            targetRotation = yawSegment.rotation * Quaternion.Euler(0f, Mathf.Clamp(angle, -yawSpeed * Time.deltaTime, yawSpeed * Time.deltaTime), 0f);
            if (yawLimit < 360f && yawLimit > 0f) yawSegment.rotation = Quaternion.RotateTowards(yawSegment.parent.rotation * yawSegmentStartRotation, targetRotation, yawLimit);
            else yawSegment.rotation = targetRotation;
        }


        if (pitchSegment && pitchLimit != 0f)
        {
            targetRelative = pitchSegment.InverseTransformPoint(tt.transform.position);
            angle = -Mathf.Atan2(targetRelative.y, targetRelative.z) * Mathf.Rad2Deg;
            if (angle >= 180f) angle = 180f - angle; if (angle <= -180f) angle = -180f + angle;
            targetRotation = pitchSegment.rotation * Quaternion.Euler(Mathf.Clamp(angle, -pitchSpeed * Time.deltaTime, pitchSpeed * Time.deltaTime), 0f, 0f);
            if (pitchLimit < 360f && pitchLimit > 0f) pitchSegment.rotation = Quaternion.RotateTowards(pitchSegment.parent.rotation * pitchSegmentStartRotation, targetRotation, pitchLimit);
            else pitchSegment.rotation = targetRotation;
        }

        Debug.DrawLine(pitchSegment.position, target, Color.red);
        Debug.DrawRay(pitchSegment.position, pitchSegment.forward * (target - pitchSegment.position).magnitude, Color.green);
    }
}
