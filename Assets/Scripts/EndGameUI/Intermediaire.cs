using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intermediaire
{
    /* Cette classe permet de daire l'intermédiaire endre des objets statiques d'une classe 
    et une fonction non statique d'une autre
    
    Celà est nécéssaire au fonctionnement de l'UI de fin de partie, par exemple. */

    public static string submitString;
    public static bool submit = false;

    public static void setSubmitString(string s){
        submitString = s;
    }

    public static void Submit(bool sub){
        submit = sub;
    }
}
