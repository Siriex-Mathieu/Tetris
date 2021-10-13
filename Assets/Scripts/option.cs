using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class option : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
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

    public void stopGame(){
        Application.Quit();
    }
}
