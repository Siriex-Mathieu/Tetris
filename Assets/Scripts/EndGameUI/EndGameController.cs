using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

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
                SendToDatabase();
            }
            else{
                Leaderboard.CheckValue(oldhighusername,highbefore);
                PlayerPrefs.SetString("HighscoreS",Intermediaire.submitString);
                SendToDatabase();
            }
            Intermediaire.submit = false;
            PlayerPrefs.SetInt("Score",0);
            SceneManager.LoadScene("StartMenu");
        }
    }

    void SendToDatabase(){
        StartCoroutine(sendData(Intermediaire.submitString,score));
        Debug.Log("envoi a la bd...");
    }

    IEnumerator sendData(string username, int score){
        Debug.Log("envoi des donnees...");
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("score", score.ToString());
        using (UnityWebRequest www = UnityWebRequest.Post("https://webinfo.iutmontp.univ-montp2.fr/~semener/Website/DB/ajoutscore.php",form)){
            yield return www.SendWebRequest();
            if(www.result == UnityWebRequest.Result.ProtocolError || www.result == UnityWebRequest.Result.ConnectionError){
                Debug.Log(www.error);
            }
            else{
                Debug.Log("envoi a la BD confirme");
            }
        }
    }
}
