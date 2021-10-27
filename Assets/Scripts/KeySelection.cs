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
    Settings file = Settings.init();// récupération du singleton 

    // touche qui sera à sauvegarder
    string touche;

     void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Escape))// si la touche échape est appuyée alors on désactive le menu
            DesactiveMenu();
        if(getKey){ // si le menu est actif le test est fait
            if(Input.anyKeyDown){ // si une quelqu'onque touche est appuyée
                foreach (KeyCode key in Enum.GetValues(typeof(KeyCode))) // chercher parmis les touches qui existe
                {
                    if(Input.GetKeyDown(key)) { // si la touche key est actuellement appuyée
                        file.change(touche, key.ToString()); // alors on change la touche "touche" est attribuée à key
                        DesactiveMenu(); // et cela désactive le menu
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

    // permet de lancer le menu et de choisir la touche à sauvegarder, cela est passé en paramêtre par le bouton
    public void menu(string t){
        touche = t;
        ActiveMenu();
    }


}