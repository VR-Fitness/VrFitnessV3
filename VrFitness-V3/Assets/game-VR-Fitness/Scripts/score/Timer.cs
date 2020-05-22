
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{  
   // public TextMeshProUGUI timerText; // UI text
    private float timePased; // play time in seconds

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.TimePlayed(0); // reset time
    }

    // Update is called once per frame
    void Update()
    {
        timePased += Time.deltaTime;  //count time     
        PlayerStats.TimePlayed(timePased);//foramt time H/M/S
       // timerText.text = "Time: " + System.Environment.NewLine + PlayerStats.timeSpan.Minutes.ToString() + ":" + PlayerStats.timeSpan.Seconds.ToString(); ;        
    }
}
