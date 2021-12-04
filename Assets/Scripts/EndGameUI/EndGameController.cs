using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    public GameObject EndGameUI;
    public Text scoreText;

    private int score,highscore,highbefore;
    private string oldhighusername, currentscore;

    void Awake(){
        score = PlayerPrefs.GetInt("Score");
        highscore = PlayerPrefs.GetInt("Highscore");
        highbefore = PlayerPrefs.GetInt("HighBefore");
        oldhighusername = PlayerPrefs.GetString("HighscoreS");
        currentscore = PlayerPrefs.GetInt("Score").ToString();
        Debug.Log(currentscore);
    }

    void Update(){
        scoreText.text = "Votre score : " + currentscore;
        if(Intermediaire.submit){
            if(score<highscore){
                Leaderboard.CheckValue(Intermediaire.submitString,score);
            }
            else{
                Leaderboard.CheckValue(oldhighusername,highbefore);
                PlayerPrefs.SetString("HighscoreS",Intermediaire.submitString);
            }
            Intermediaire.submit = false;
            SceneManager.LoadScene("StartMenu");
        }
    }
}
