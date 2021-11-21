using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    private static int[] valuearray;

    public Text h1,h2,h3,h4,h5,h6,h7,h8,h9,h10;

    void Start(){
    }

    void Update(){ // afficher les textes sur la scene (il y'a certaiement un moyen d'optimiser ce que j'ai fait)
        h1.text = PlayerPrefs.GetInt("Highscore").ToString();
        h2.text = PlayerPrefs.GetInt("Highscore2").ToString();
        h3.text = PlayerPrefs.GetInt("Highscore3").ToString();
        h4.text = PlayerPrefs.GetInt("Highscore4").ToString();
        h5.text = PlayerPrefs.GetInt("Highscore5").ToString();
        h6.text = PlayerPrefs.GetInt("Highscore6").ToString();
        h7.text = PlayerPrefs.GetInt("Highscore7").ToString();
        h8.text = PlayerPrefs.GetInt("Highscore8").ToString();
        h9.text = PlayerPrefs.GetInt("Highscore9").ToString();
        h10.text = PlayerPrefs.GetInt("Highscore10").ToString();
    }


    public static void CheckValue(int t){
        Init();
        valuearray[7] = t;
        valuearray = sort(valuearray);
        Apply();
    }

    public static void Clear(){ // reinitialiser le leaderboard (pour les devs ou le menu options)
        for(int i =2;i<=10;i++){
            PlayerPrefs.SetInt("Highscore" + i, 0);
        }
    }

    public static void Show(){ // afficher le leaderboard
        for(int i =2;i<=10;i++){
            Debug.Log(i + " = " + PlayerPrefs.GetInt("Highscore" + i).ToString());
        }
    }

    public static int[] sort(int[] tab){
        int[] copy = new int[tab.Length];
        for(int i = 0;i<tab.Length;i++){
            copy[i] = tab[getHighestNumber(tab)];
            tab[getHighestNumber(tab)] = 0;
        }
        return copy;
    }

    public static int getHighestNumber(int[] tab){
        int max = 0;
        int res = 0;
        for(int i = 0; i< tab.Length;i++){
            if(tab[i]> max){ 
                max = tab[i];
                res = i;
            }
        }
        return res; 
    }


    public static void Init(){
        valuearray = new int[10];
        for(int i =0;i<valuearray.Length-1;i++){
            valuearray[i] = PlayerPrefs.GetInt("Highscore" + (i+2));
        }
    }

    public static void Apply(){
        for(int i =0;i<=8;i++){
            PlayerPrefs.SetInt("Highscore" + (i+2), valuearray[i]);
        }
    }
}
