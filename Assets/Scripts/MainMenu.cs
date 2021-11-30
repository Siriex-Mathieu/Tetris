using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2); // charger la scene n°2 => celle de l'attente
    }

    public void PlayMulti()
    {
        SceneManager.LoadScene("multi");
    }
}
