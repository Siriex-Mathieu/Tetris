using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] public static bool isPaused;

    Settings file = Settings.init();



    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {        
        // if (Input.GetKeyDown(KeyCode.Escape))
        //     DesactiveMenu();
        if (Input.GetKeyDown(KeyCode.Escape))
            DesactiveMenu();

    }

    public void ActiveMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        PauseMenuUI.SetActive(true);            
        
    }

   public void DesactiveMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        PauseMenuUI.SetActive(false);
        isPaused = false;
    }


}
