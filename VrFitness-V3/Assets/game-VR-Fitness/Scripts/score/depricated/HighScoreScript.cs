using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScoreScript : MonoBehaviour
{


    public Text HighScore;
    public Text score;


    void Start()
    {
        /*
      //  HighScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", scorescript.scoreValue).ToString(); /* scoreValue konverteres til en String, således at Game Objectet Highscore tekst  
         kan displaye scoreValuen som var i int form som en tekst. Playerprefs returner værdien der svarer til keyen i "preference" filen.   "
            */
    }

    // Update is called once per frame
    public void Update()
    {
        /*
        if (scorescript.scoreValue > PlayerPrefs.GetInt("HighScore", scorescript.scoreValue)
            )
        {
         //   PlayerPrefs.SetInt("HighScore", scorescript.scoreValue); // sætter værdien fra preference filen identificeret af en nøgle til "Highscore" tekst objektet.

           // HighScore.text = "NEW HIGHSCORE:" + scorescript.scoreValue.ToString();

        }
       */

    }


}