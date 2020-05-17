using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scorescript : MonoBehaviour
{
    public TextMeshProUGUI MultiplierText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText; // UI text
    private int ScoreAddInterval = 2; // interval of score add modifier
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.multiplierValue = 0.0f;
        PlayerStats.scoreValue = 0; // reset value
        scoreText.text = PlayerStats.scoreValue.ToString();  // reset text value     
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= ScoreAddInterval)
        {
            PlayerStats.AddScoreValue();
            timer = 0;
        }
        UpdateTextUI();
    }



    private void UpdateTextUI()
    {
        Debug.Log("UI update");
        scoreText.text = "Score:" + System.Environment.NewLine + PlayerStats.scoreValue;
        MultiplierText.text = "Multiplier:" + System.Environment.NewLine + PlayerStats.multiplierValue;
        timerText.text = "Time: " + System.Environment.NewLine + PlayerStats.GetTimePlayedMinuttes().ToString() + ":" + PlayerStats.GetTimePlayedSeconds().ToString(); 
    }


    
}