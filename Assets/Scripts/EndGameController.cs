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
        Pause.pause();
        EndGameUI.SetActive(true);
    }

    void resume(){
        Intermediaire.setLose(false);
        Pause.unpause();
        EndGameUI.SetActive(false);
    }
}
