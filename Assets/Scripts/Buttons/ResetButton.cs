using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset(){
        Leaderboard.Clear();
        HighScore.highscore = 0;
        PlayerPrefs.SetInt("Highscore", 0);
    }
}
