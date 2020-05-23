using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System;
using System.Text;
using System.IO;

public class ArduinoListener : MonoBehaviour
{

   
    float timer;

    public string path;
   // public string path = @"E:\unity projects\VrFitness-V3\Assets\game-VR-Fitness\Scripts\Puls\puls.txt";

    [SerializeField]
    private int PulsCatch;


    private void Start()
    {
        path = Application.dataPath + @"\game-VR-Fitness\Scripts\Puls\puls.txt";
    }



    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;

            try
            {
                string line;
                StreamReader theReader = new StreamReader(path, Encoding.Default);


                using (theReader)
                {
                    line = theReader.ReadLine();
                    if (line != null)
                    {
                        CatchIntArduinoCom(line);
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }
           


        }
     
    }
   


  


    private void CatchIntArduinoCom(string pulsString)
    {
        try
        {
           
                
            PulsCatch = int.Parse(pulsString);
            Debug.Log(PulsCatch);
            PlayerStats.playerBPM = PulsCatch;
           
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex);
        }
    }

   
}
