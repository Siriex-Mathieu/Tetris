// Detects keys pressed and prints their keycode
// https://docs.unity3d.com/ScriptReference/Event-keyCode.html
using UnityEngine;
using System.Collections;
using System;

public class KeySelection : MonoBehaviour
{
    
    [SerializeField] private GameObject getKeyMenu;

    [SerializeField] private static bool getKey;

    Settings file = Settings.init();

    private string prin ;
     void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Escape))
            DesactiveMenu();
        if(getKey){
            if(Input.anyKeyDown){
                foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
                {
                    if(Input.GetKeyDown(key)) print(key);
                    // TODO il faut pouvoir remonter jusqu'à tetris block pour y changer les touches
                }
            }
        }
    }

    public void ActiveMenu()
    {
        getKeyMenu.SetActive(true);
        getKey = true;            
        
    }

   public void DesactiveMenu()
    {
        getKeyMenu.SetActive(false);
        getKey = false;
    }

}