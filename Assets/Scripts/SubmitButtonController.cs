using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitButtonController : MonoBehaviour
{
    public GameObject button;

    public void OnClick(string s){
        Intermediaire.setSubmitString(s);
        Intermediaire.Submit(true);
    }
}
