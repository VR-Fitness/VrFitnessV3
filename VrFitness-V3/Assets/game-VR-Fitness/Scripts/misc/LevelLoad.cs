using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{

    public int GameLengthMinuttes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.GetTimePlayedMinuttes() >= GameLengthMinuttes)
        {
          //  Debug.Log("end game");
            LoadLevelComplete();
        }
    }



    private void LoadLevelComplete()
    {
        // Load the level named "HighScore".
       // Application.LoadLevel("Menu");
        SceneManager.LoadScene("menu");
    }
}
