using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StreakMulti : MonoBehaviour
{
    public static int Difficulty = 1;
    public static int MaxLevel = 70;
    public static float ScoreToNextLevel = 400.0f;
    public static float Enemycount = 3;
    public static int ScoreStreakValue;
    public Text ScoreStreak;


    void Start()
    {
        ScoreStreak = GetComponent<Text>();
        ScoreStreakValue = 1;
    }

    /*
    void Update()
    { 
        ScoreStreak.text = "Combo:" + ScoreStreakValue;
        if (scorescript.scoreValue>=ScoreToNextLevel)
        {
            LevelUp();
        }
        }

    void LevelUp()
    
    {

        if (Difficulty >= MaxLevel)
            return;
      
        Difficulty++;
        Enemycount++;

        ScoreToNextLevel=Mathf.Round( ScoreToNextLevel* 1.7f);
        Debug.Log("Difficulty " + Difficulty);
        
       // Enemycount=Mathf.Round(Enemycount * 1.2f);
        Debug.Log("Enemycount "  + Enemycount);
        Debug.Log("ScoreToNextLevel " + ScoreToNextLevel);
    }
    */
}