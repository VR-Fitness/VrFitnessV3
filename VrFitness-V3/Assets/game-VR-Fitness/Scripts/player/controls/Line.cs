using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    public float Distance = 20.0f;
    private LineRenderer lineRenderer = null;



    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

      
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLine();
    }


    private void UpdateLine()
    {
        float targetLength = Distance;

       
        Vector3 endPosition = transform.position + (transform.forward * targetLength);

      

       
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);
    }
}
