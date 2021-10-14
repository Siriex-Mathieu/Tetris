using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] public static bool isPaused;


    [SerializeField] private GameObject getKeyMenu;

    [SerializeField] private static bool getKey;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Escape))
            DesactiveMenu();
        // if (Input.GetKeyDown(KeyCode.Escape))
        //     if(getKey) getKey = false;
        //     else DesactiveMenu();
        // if(getKey){
        //     ActiveGetKey();
        // }
        // else DesactiveGetKey();
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

//    public void DesactiveGetKey(){
//        getKeyMenu.SetActive(false);
//        getKey = false;
//    }

//    public void ActiveGetKey(){
//        getKeyMenu.SetActive(true);
//        getKey = true;
//    }


}
