using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubmitButtonController : MonoBehaviour
{

    public void Submit(){
        Intermediaire.submit = true;
    }

    public void Quit(){
        Debug.Log("High = " + PlayerPrefs.GetInt("Highscore").ToString() + " HighB = " + PlayerPrefs.GetInt("HighBefore").ToString());
        PlayerPrefs.SetInt("Highscore",PlayerPrefs.GetInt("HighBefore"));
        SceneManager.LoadScene("StartMenu");
    }

}
