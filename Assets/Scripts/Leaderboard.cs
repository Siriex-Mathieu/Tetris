using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    private static int[] valuearray;

    public Text h2,h3,h4,h5,h6,h7,h8,h9;

    void Start(){ 
        
    }

    void Update(){ // afficher les textes sur la scene (il y'a certaiement un moyen d'optimiser ce que j'ai fait)
        h2.text = PlayerPrefs.GetInt("Highscore2").ToString();
        h3.text = PlayerPrefs.GetInt("Highscore3").ToString();
        h4.text = PlayerPrefs.GetInt("Highscore4").ToString();
        h5.text = PlayerPrefs.GetInt("Highscore5").ToString();
        h6.text = PlayerPrefs.GetInt("Highscore6").ToString();
        h7.text = PlayerPrefs.GetInt("Highscore7").ToString();
        h8.text = PlayerPrefs.GetInt("Highscore8").ToString();
        h9.text = PlayerPrefs.GetInt("Highscore9").ToString();
    }


    public static void CheckValue(int t){
        valuearray[8] = t;
        Sort();
        Apply();
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

    public static void Sort(){
        int[] copy = new int[8];
        for(int i = 0;i<=7;i++ ){}
    }

    public static void Init(){
        valuearray = new int[8];
        for(int i =0;i<=8;i++){
            valuearray[i] = PlayerPrefs.GetInt("Highscore" + (i+2));
        }
    }

    public static void Apply(){
        for(int i =0;i<=8;i++){
            PlayerPrefs.SetInt("Highscore" + (i+2), valuearray[i]);
        }
    }
}
