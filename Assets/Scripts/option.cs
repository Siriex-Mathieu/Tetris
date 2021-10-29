using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuUI; // objet du menu
    [SerializeField] public static bool isPaused; // Savoir si le menu est actif ou pas

    Settings file = Settings.init(); // récupération du singleton 



    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Escape)) // si la touche échape est appuyée alors on désactive le menu
            DesactiveMenu();

    }

    public void ActiveMenu() // fonction d'activation du menu
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        PauseMenuUI.SetActive(true);            
        
    }

   public void DesactiveMenu() // désactivation du menu
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        PauseMenuUI.SetActive(false);
        isPaused = false;
    }
    public void stopGame(){
        Application.Quit();
    }
}
