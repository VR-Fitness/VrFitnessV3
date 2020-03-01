using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class VFXmixer : MonoBehaviour
{

    public VisualEffect visualEffect;
    public AudioData_AmplitudeBand audioData_AmplitudeBand;
   // private float amplitude;
   // private float amplitudeBuffer;

    // Start is called before the first frame update
    void Start()
    {
        //audioData_AmplitudeBand.Amplitude;
        //audioData_AmplitudeBand.AmplitudeBuffer;
    }

    // Update is called once per frame
    void Update()
    {
        // visualEffect.SetFloat("Radius", audioData_AmplitudeBand.Amplitude * 100);


        float x = (audioData_AmplitudeBand.Amplitude) * 100;
        float y = (audioData_AmplitudeBand.Amplitude) * 100;
        float z = (audioData_AmplitudeBand.Amplitude) * 100;

       

        visualEffect.SetVector3("RGB-ADD-Color", new Vector3(x,y,z));

        visualEffect.SetFloat("spawn", audioData_AmplitudeBand.Amplitude);
       // visualEffect.SetFloat("raduis", audioData_AmplitudeBand.Amplitude * audioData_AmplitudeBand.AmplitudeBuffer);
    }
}
