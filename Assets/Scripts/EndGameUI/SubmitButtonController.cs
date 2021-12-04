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
        SceneManager.LoadScene("StartMenu");
    }

    public void ReadStringInput(string s){
        Debug.Log(s);
        Intermediaire.submitString = s;
        Debug.Log(Intermediaire.submitString);
    }
}
