using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Text;

/**
 * Classe qui permet d'accéder et modifier des fichiers, principalement des fichiers config .cfg
 */
public class AccessFile : MonoBehaviour
{
    public static void Set(string field, string value, FileName file){

        // Récupération du fichier 
        FileStream fs = new FileStream( 
                                        FileNameMap.map[(int)file], 
                                        FileMode.OpenOrCreate,
                                        FileAccess.ReadWrite, 
                                        FileShare.None);

        // Initialisation du bidule de lecture (je ne comprend pas trop comment cela fonctionne conrètement)
        byte[] b = new byte[1024];
        UTF8Encoding temp = new UTF8Encoding(true);

        // initialisation des variables utilisés après
        string text;
        string nextText;
        string[] tab = new string[2];
        
        // Variable de debug pour eviter les tours de boucles infini
        int loop = 10000;


        // Parcours du fichier
        while(fs.Read(b,0,b.Length)>0){
            
            // initialisation des variables
            text = temp.GetString(b);
            // premier tours de boucle de nextText
            nextText = text;

            while (nextText != null)
            {
                loop--;
                
                tab = GetNextLine(nextText); // Récupération de la premiere ligne

                if (tab[0].Contains(field)) // si la ligne contient le champs voulu
                {
                    // il faut écrire à cet endroit, l'idée est de récupérer la position pour écrire ici sans avoir de problème si la taille du texte change
                    // il ne faut pas que si le texte est plus grand, le reste du document soit écrasé en plein milieux
                    // il ne faut pas que si le texte est plus petit, une partie de l'ancien texte reste
                    print("ici ça marche");
                    break;
                }

                if(loop ==0) { // si trop de tours de boucle ont étés fait
                    print("Trop de tours de boucle");
                    break;
                }

                nextText = tab[1]; // récupération du reste du texte pour le prochain tours de boucle
            }
        }

        // fermeture du lecteur de fichier important, ne pas enlever
        fs.Close();
    }


    /**
        Fonction qui prend en entrée un texte d'une ou plusieurs lignes et ressort un tableau de 2 string
        tab[0] représente la première ligne
        tab[1] représente le reste du tableau
    */
    public static string[] GetNextLine(string text){

        // Initialisation des variables
        // tableau de caractères pour se balader dedans facilement
        char[] tab = text.ToCharArray();
        // index de la fin de la première ligne
        int index = 0;

        // variable pour le resultat
        string[] res = new string[2];

        // variable de debug pour éviter les tours de boucles infini
        int loop = 1000;


        // Parcours du tableau
        foreach (char carac in tab)
        {
            loop--;
            
            // si un retours à la ligne est détecté alors on renvoi le bon résultat
            if (carac == '\n')
            {
                
                res[0] = text.Substring(0,index+1); // Attribution de la première ligne
                if (index+1 == text.Length) res[1] = null; // Si la ligne trouvée est la dernière ligne
                else res[1] = text.Substring(index+1); // texte restant sinon

                return res;

            }

            // cas de tours de boucle trop long
            if(loop ==0) { 
                print("Erreur : Tours de boucle trop long"); 
                return null;
            }
            index++;
        }

        // renvoi si il n'y a pas de \n de trouvé (ce qui n'est pas sensé arriver)
        res[0] = text; // Attribution de la première ligne
        res[1] = null; // texte restant
        return res;
        
    }


}


/**
 * Pour que tout se passe correctement, � chaque ajout de fichier .cfg, il faut que le fichier soit ajout� pour que le syst�me le prenne en compte.
 */
public enum FileName
{
    stringKeySettings = 0,
    GlobalSettings = 1

}
public static class FileNameMap{
    public static string[] map = new string[] {"Assets/Settings/KeysSetting.cfg","Assets/Settings/GlobalSetting.cfg"};

}