using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    //public string nomJoueur;

       /*void UpdateLeaderboard(){
        for(int i =2;i<=9;i++){
            if(Score.score > PlayerPrefs.GetInt("Highscore" + i)){
                Debug.Log("Leaderboard updated");
                PlayerPrefs.SetInt(convert(i), PlayerPrefs.GetInt("Highscore" + i));
                PlayerPrefs.SetInt("Highscore" + i,Score.score);
                Debug.Log(i +" = " + PlayerPrefs.GetInt("Highscore" + i).ToString());
            }
        }
    }*/

    void Start(){

    }

        public static void CheckValue(int t){
            for(int i =2;i<=9;i++){
                if(HighScore.highscore > t && t > PlayerPrefs.GetInt("Highscore" + i)){
                    Debug.Log("Leaderboard updated");
                    PlayerPrefs.SetInt("Highscore" + i,t);
                    Debug.Log(i +" = " + PlayerPrefs.GetInt("Highscore" + i).ToString());
                }
            }
        }

        public static void Clear(){ // reinitialiser le leaderboard (pour les devs ou le menu options)
            for(int i =2;i<=9;i++){
                PlayerPrefs.SetInt("Highscore" + i, 0);
            }
        }

        public static void Show(){ // afficher le leaderboard
            for(int i =2;i<=9;i++){
                Debug.Log(i + " = " + PlayerPrefs.GetInt("Highscore" + i).ToString());
            }
        }
}
