using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameController : MonoBehaviour
{
    public GameObject EndGameUI;

    void Update(){
        while(Intermediaire.lose){
            pause();
            if(Intermediaire.submit){
                resume();
            }
        }
    }

    void pause(){
        EndGameUI.SetActive(true);
        Time.timeScale = 0;
    }

    void resume(){
        EndGameUI.SetActive(false);
        Time.timeScale =1;
    }
}
