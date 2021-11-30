using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public static int highscore;
    public static int highBefore;
    public static string username;

    public Text text;
    Color gold;
    void Start()
    {
        ColorUtility.TryParseHtmlString("#CBAF3D", out gold);
        text.text = PlayerPrefs.GetInt("Highscore").ToString();
        highBefore =  PlayerPrefs.GetInt("Highscore");
        highscore = PlayerPrefs.GetInt("Highscore");
    }

    void Update()
    {
        if(Score.score > highBefore){
            text.color = gold;
            text.text = Score.score.ToString();
            PlayerPrefs.SetInt("Highscore", Score.score);
            highscore = PlayerPrefs.GetInt("Highscore");
        }
    }

}
