using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeValue = 0;
    public float startTimeValue = 180;

    [SerializeField] Text countTime;
    
    void Start()
    {
        timeValue = startTimeValue;
    }

    // Update is called once per frame
    void Update()
    {
        timeValue -= 1 * Time.deltaTime;
        countTime.text = timeValue.ToString("0");

            if (timeValue <= 0){
                Pause.QuitGame2();
            }
    }
}
