using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public GameObject read;

    public void ReadStringInput(){
        Debug.Log(read.GetComponent<Text>().text);
        Intermediaire.submitString = read.GetComponent<Text>().text;
        Debug.Log(Intermediaire.submitString);
    }
}
