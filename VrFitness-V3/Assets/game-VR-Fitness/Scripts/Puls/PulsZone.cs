using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsZone : MonoBehaviour
{


    /*
    Zone 1: Opvarmning (50-59%)
    Zone 2: Fedtforbrænding (60-69%)
    Zone 3 : Aerob (70-79%)
    Zone 4 : Anaerob (80-89%)
    Zone 5: Maksimum (90-100%)    

    */

    public int age = 13;
    public float PulseZone1;
    public float PulseZone2;
    public float PulseZone3;
    public float PulseZone4;
    public float PulseZone5;
    public float Pulsreserve;

   
    private SpawnController spawnController;
    private float timerCount;



    // Start is called before the first frame update
    void Start()
    {

        spawnController = this.GetComponent<SpawnController>();

        CalcPulsMinMax(age);

        Pulsreserve = PlayerStats.PulsMax - PlayerStats.PulsMin;
        
        PulseZone1 = (Pulsreserve*(50f/100f)) + PlayerStats.PulsMin;
        PulseZone2 = (Pulsreserve * (60f/100f)) + PlayerStats.PulsMin;
        PulseZone3 = (Pulsreserve * (70f / 100f)) + PlayerStats.PulsMin;
        PulseZone4 = (Pulsreserve * (80f / 100f)) + PlayerStats.PulsMin;
        PulseZone5 = (Pulsreserve * (90f / 100f)) + PlayerStats.PulsMin;


        spawnController.spawnDelay = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timerCount += Time.deltaTime;

        if (timerCount > 2)
        {
            AdjustSpawnSettings();
            timerCount = 0;
        }

    }


    private static void CalcPulsMinMax(int age)
    {
        PlayerStats.PulsMax = 208 - 0.7f * age;

        if (age >= 10)
        {
            PlayerStats.PulsMin = 80;  // avereage from teori 60-100
        }
        else if (age >= 7)
        {
            PlayerStats.PulsMin = 90;  // avereage from teori 70-110
        }
        else
        {
            PlayerStats.PulsMin = 96;  // avereage from teori 75-115
        }

    }



    private void AdjustSpawnSettings()
    {
        if (PlayerStats.GetTimePlayedMinuttes() < 1)
        {
            if (PlayerStats.playerBPM > PulseZone1)
            {              
                spawnController.DecreaseSpeed();
              // spawnController.DecreaseSpawnDelay();
                spawnController.DecreasShipSpawnChanceProcent();
            }
            else if (PlayerStats.playerBPM < PulseZone1)
            {
                spawnController.IncreaseSpeed();
                //spawnController.IncreaseSpawnDelay();
                spawnController.IncreasShipSpawnChanceProcent();
            }
        }

        if (PlayerStats.GetTimePlayedMinuttes() >= 1 && PlayerStats.GetTimePlayedMinuttes() < 2)
        {
            spawnController.spawnDelay = 0.9f;
            if (PlayerStats.playerBPM > PulseZone2)
            {
                spawnController.DecreaseSpeed();
              //  spawnController.DecreaseSpawnDelay();
                spawnController.DecreasShipSpawnChanceProcent();
            }
            else if (PlayerStats.playerBPM < PulseZone2)
            {
                spawnController.IncreaseSpeed();
                ///spawnController.IncreaseSpawnDelay();
                spawnController.IncreasShipSpawnChanceProcent();
            }
        }

        if (PlayerStats.GetTimePlayedMinuttes() >= 2 && PlayerStats.GetTimePlayedMinuttes() < 3)
        {
            spawnController.spawnDelay = 0.5f;
            if (PlayerStats.playerBPM > PulseZone3)
            {
                spawnController.DecreaseSpeed();
                //spawnController.DecreaseSpawnDelay();
                spawnController.DecreasShipSpawnChanceProcent();
            }
            else if (PlayerStats.playerBPM < PulseZone3)
            {
                spawnController.IncreaseSpeed();
                //spawnController.IncreaseSpawnDelay();
                spawnController.IncreasShipSpawnChanceProcent();
            }
        }

        if (PlayerStats.GetTimePlayedMinuttes() >= 3 && PlayerStats.GetTimePlayedMinuttes() < 4)
        {
            spawnController.spawnDelay = 0.5f;
            if (PlayerStats.playerBPM > PulseZone4)
            {
                spawnController.DecreaseSpeed();
                //spawnController.DecreaseSpawnDelay();
                spawnController.DecreasShipSpawnChanceProcent();
            }
            else if (PlayerStats.playerBPM < PulseZone4)
            {
                spawnController.IncreaseSpeed();
                //spawnController.IncreaseSpawnDelay();
                spawnController.IncreasShipSpawnChanceProcent();
            }
        }
        if (PlayerStats.GetTimePlayedMinuttes() >= 4 && PlayerStats.GetTimePlayedMinuttes() < 5)
        {
            spawnController.spawnDelay = 0.3f;
            if (PlayerStats.playerBPM > PulseZone5)
            {
                spawnController.DecreaseSpeed();
                //spawnController.DecreaseSpawnDelay();
                spawnController.DecreasShipSpawnChanceProcent();
            }
            else if (PlayerStats.playerBPM < PulseZone5)
            {
                spawnController.IncreaseSpeed();
                //spawnController.IncreaseSpawnDelay();
                spawnController.IncreasShipSpawnChanceProcent();
            }
        }
        if (PlayerStats.GetTimePlayedMinuttes() >= 5 && PlayerStats.GetTimePlayedMinuttes() < 6)
        {
            spawnController.spawnDelay = 0.3f;
            if (PlayerStats.playerBPM > PulseZone5)
            {
                spawnController.DecreaseSpeed();
                //spawnController.DecreaseSpawnDelay();
                spawnController.DecreasShipSpawnChanceProcent();
            }
            else if (PlayerStats.playerBPM < PulseZone5)
            {
                spawnController.IncreaseSpeed();
                //spawnController.IncreaseSpawnDelay();
                spawnController.IncreasShipSpawnChanceProcent();
            }
        }
        if (PlayerStats.GetTimePlayedMinuttes() >= 6 && PlayerStats.GetTimePlayedMinuttes() < 7)
        {
            spawnController.spawnDelay = 0.8f;
            if (PlayerStats.playerBPM > PulseZone3)
            {
                spawnController.DecreaseSpeed();
                //spawnController.DecreaseSpawnDelay();
                spawnController.DecreasShipSpawnChanceProcent();
            }
            else if (PlayerStats.playerBPM < PulseZone3)
            {
                spawnController.IncreaseSpeed();
                //spawnController.IncreaseSpawnDelay();
                spawnController.IncreasShipSpawnChanceProcent();
            }
        }
        if (PlayerStats.GetTimePlayedMinuttes() >= 7 && PlayerStats.GetTimePlayedMinuttes() < 8)
        {
            spawnController.spawnDelay = 0.8f;
            if (PlayerStats.playerBPM > PulseZone3)
            {
                spawnController.DecreaseSpeed();
                //spawnController.DecreaseSpawnDelay();
                spawnController.DecreasShipSpawnChanceProcent();
            }
            else if (PlayerStats.playerBPM < PulseZone3)
            {
                spawnController.IncreaseSpeed();
                //spawnController.IncreaseSpawnDelay();
                spawnController.IncreasShipSpawnChanceProcent();
            }
        }
        if (PlayerStats.GetTimePlayedMinuttes() >= 8 && PlayerStats.GetTimePlayedMinuttes() < 10)
        {
            spawnController.spawnDelay = 1.5f;
            if (PlayerStats.playerBPM > PulseZone3)
            {
                spawnController.DecreaseSpeed();
                //spawnController.DecreaseSpawnDelay();
                spawnController.DecreasShipSpawnChanceProcent();
            }
            else if (PlayerStats.playerBPM < PulseZone3)
            {
                spawnController.IncreaseSpeed();
                //spawnController.IncreaseSpawnDelay();
                spawnController.IncreasShipSpawnChanceProcent();
            }
        }
    }


}
