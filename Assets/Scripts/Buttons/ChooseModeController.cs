using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseModeController : MonoBehaviour
{
    public void PlaySolo(){
        SceneManager.LoadScene("Main");
    }

    public void PlayMulti(){
        SceneManager.LoadScene("multi");
    }

    public void Play3min(){
        SceneManager.LoadScene("mode1");
    }

    public void StartMenu(){
        SceneManager.LoadScene("StartMenu");
    }
}
