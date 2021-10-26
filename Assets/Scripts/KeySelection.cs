// Detects keys pressed and prints their keycode
// https://docs.unity3d.com/ScriptReference/Event-keyCode.html
using UnityEngine;
using System.Collections;
using System;

public class KeySelection : MonoBehaviour
{
    // objet du menu
    [SerializeField] private GameObject getKeyMenu;


    // getKey permet de limiter la boucle uniquement au moment où le menu est ouvert
    bool getKey;

    // accès au singleton des setting
    Settings file = Settings.init();

    // touche qui sera à sauvegarder
    string touche;

     void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Escape))
            DesactiveMenu();
        if(getKey){
            if(Input.anyKeyDown){
                foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
                {
                    if(Input.GetKeyDown(key)) {
                        file.change(touche, key.ToString());
                        DesactiveMenu();
                    }

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

    // permet de lancer le menu et de choisir la touche à sauvegarder
    public void menu(string t){
        touche = t;
        ActiveMenu();
    }


}