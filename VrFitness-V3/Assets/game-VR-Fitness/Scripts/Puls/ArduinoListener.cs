using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class ArduinoListener : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM4", 2000000);

    [SerializeField]
    private int PulsCatch;

    // Start is called before the first frame update
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CatchIntArduinoCom();
    }



    private void CatchIntArduinoCom()
    {
        try
        {
            PulsCatch = int.Parse(sp.ReadLine());
            Debug.Log(PulsCatch);
            PlayerStats.playerBPM = PulsCatch;
            // Debug.Log(sp.ReadLine());
            //print(sp.ReadLine());
        }
        catch (System.Exception)
        {

        }
    }
}
