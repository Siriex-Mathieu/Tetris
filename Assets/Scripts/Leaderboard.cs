using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    private static object[,] valuearray;

    public Text h1,h2,h3,h4,h5,h6,h7,h8,h9,h10;
    public Text s1,s2,s3,s4,s5,s6,s7,s8,s9,s10;

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
        s1.text = PlayerPrefs.GetString("HighscoreS");
        s2.text = PlayerPrefs.GetString("HighscoreS2");
        s3.text = PlayerPrefs.GetString("HighscoreS3");
        s4.text = PlayerPrefs.GetString("HighscoreS4");
        s5.text = PlayerPrefs.GetString("HighscoreS5");
        s6.text = PlayerPrefs.GetString("HighscoreS6");
        s7.text = PlayerPrefs.GetString("HighscoreS7");
        s8.text = PlayerPrefs.GetString("HighscoreS8");
        s9.text = PlayerPrefs.GetString("HighscoreS9");
        s10.text = PlayerPrefs.GetString("HighscoreS10");
    }


    public static void CheckValue(string un,int t){
        Init();
        valuearray[valuearray.Length/2 -1,1] = t;
        valuearray[valuearray.Length/2 -1,0] = un;
        valuearray = sort(valuearray);
        for(int i=0;i<=8;i++){
            Debug.Log((string)valuearray[i,0]);
            Apply((string)valuearray[i,0],(int)valuearray[i,1],i);
        }
    }

    public static void Clear(){ // reinitialiser le leaderboard (pour les devs ou le menu options)
        for(int i =2;i<=10;i++){
            PlayerPrefs.SetInt("Highscore" + i, 0);
            PlayerPrefs.SetString("HighscoreS" + i, "/");
        }
    }

    public static void Show(){ // afficher le leaderboard
        for(int i =2;i<=10;i++){
            Debug.Log(i + " = " + PlayerPrefs.GetInt("Highscore" + i).ToString());
        }
    }

    public static object[,] sort(object[,] tab){
        object[,] copy = new object[tab.Length,2];
        for(int i = 0;i<tab.Length/2;i++){
            copy[i,0] = tab[getHighestNumber(tab),0];
            copy[i,1] = tab[getHighestNumber(tab),1];
            tab[getHighestNumber(tab),0] = "/";
            tab[getHighestNumber(tab),1] = 0;
        }
        return copy;
    }

    public static int getHighestNumber(object[,] tab){
        int max = 0;
        int res = 0;
        for(int i = 0; i< tab.Length/2;i++){
            if((int)tab[i,1]> max){ 
                max = (int)tab[i,1];
                res = i;
            }
        }
        return res; 
    }


    public static void Init(){
        valuearray = new object[10,2];
        for(int i =0;i<valuearray.Length/2;i++){
            valuearray[i,0] = PlayerPrefs.GetString("HighscoreS" + (i+2));
            valuearray[i,1] = PlayerPrefs.GetInt("Highscore" + (i+2));
        }
    }

    public static void Apply(string s, int valeur, int start){
        PlayerPrefs.SetString("HighscoreS" + (start+2), s);
        PlayerPrefs.SetInt("Highscore" + (start+2), valeur);
    }
}
