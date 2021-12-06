using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("GamemodeSelect"); // charger la scene n°2 => celle de l'attente
    }

    public static void PlayMulti()
    {
        SceneManager.LoadScene("multi");
    }

    public void LeaderBoard(){
        SceneManager.LoadScene("Leaderboard");
    }
}
