// Detects keys pressed and prints their keycode
// https://docs.unity3d.com/ScriptReference/Event-keyCode.html
using UnityEngine;
using System.Collections;

public class KeySelection : MonoBehaviour
{
    
    [SerializeField] private GameObject getKeyMenu;

    [SerializeField] private static bool getKey;
     void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Escape))
            DesactiveMenu();

    }

    public void ActiveMenu()
    {
        getKeyMenu.SetActive(true);            
        
    }

   public void DesactiveMenu()
    {
        getKeyMenu.SetActive(false);
    }

}