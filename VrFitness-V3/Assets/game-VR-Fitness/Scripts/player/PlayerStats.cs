using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats 
{
    public static float PulsMax  ; // calculted from "208 – 0,7 x alder" 208 – 0,7 x 13
    public static float PulsMin  ; // avereage from teori 60-100

    public static float multiplierValue;
    public static int scoreValue; // score value
    //public static int damageValue;//damage value
    public static int playerBPM;// player pulse pr minute


    private static TimeSpan timeSpan;// player time playing
    private static int damageTakeAmount = 100;
    private static int scoreGiveAmount = 10;
    private static float MultiplierAmount = 0.1f;



   

    public static int GetTimePlayedMinuttes()
    {
        return timeSpan.Minutes;
    }

    public static int GetTimePlayedSeconds()
    {
        return timeSpan.Seconds;
    }



    public static void ResetMultiplier()
    {
        multiplierValue = 0;
    }

    public static void AddMultiplierValue()
    {
        multiplierValue += MultiplierAmount;
       
    }

    public static void TimePlayed(float timePased)
    {
        timeSpan = TimeSpan.FromSeconds(timePased);
    }

    public static void Addamage()
    {
        int scoreSum = scoreValue -= damageTakeAmount;

        if (scoreSum <= 0)
        {
            scoreValue = 0;
        }
        else
        {
            scoreValue = scoreSum;
        }
       
    }

    public static void AddScoreValue()
    {
        float calcscore = (scoreGiveAmount * multiplierValue);

        if (scoreValue ==  0 || multiplierValue == 0.1f)
        {
            scoreValue += 1;
        }
        else
        {
            scoreValue += (int)calcscore;
        }
       
    }
}
