using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class tetrisBlock : MonoBehaviour
{
    public bool lose = false;
    private float previousTime;
    public float fallTime = 0.5f;//Temps pour la piece de tomber
    private static int height = 20; //Hauteur
    private static int width = 10; //Longueur

    public bool mainPlayer;
    private KeyCode gauche = KeyCode.LeftArrow; //Appui sur <- 
    private KeyCode droite = KeyCode.RightArrow;//Appui sur ->
    private KeyCode bas = KeyCode.DownArrow;
    private KeyCode basRapide = KeyCode.RightControl;
    private KeyCode rotationD = KeyCode.L;
    private KeyCode rotaionG = KeyCode.M;

    private Settings settings;


    private static Transform[,] grid = new Transform[width, height]; //Pour les collision entre les block

    public Vector3 RotationBlock; //Rotation



    private void init()
    {
        if (settings == null)
        {
            settings = Settings.init();
        }
        gauche = (KeyCode)Enum.Parse(typeof(KeyCode), settings.move_left);
        droite = (KeyCode)Enum.Parse(typeof(KeyCode), settings.move_right);
        bas = (KeyCode)Enum.Parse(typeof(KeyCode), settings.move_down);
        basRapide = (KeyCode)Enum.Parse(typeof(KeyCode), settings.drop);
        rotaionG = (KeyCode)Enum.Parse(typeof(KeyCode), settings.turn_left);
        rotationD = (KeyCode)Enum.Parse(typeof(KeyCode), settings.turn_right);

    }


    /**
    * 1er Fonction qui demarre quand on apelle la classe
    */
    void Start()
    {
        if (mainPlayer)
        {
            init();
        }
        else
        {
            width = 30;
        }

    }

    /**
    *
    * Fonction qui s'apelle AUTOMATIQUEMENT a chaque tick du jeu (1msec)
    *
    */
    void Update()
    {
        if (mainPlayer && settings.modified)
        {
            // Actualisation des touches
            init();
            settings.modified = false; // les touches sont actualisées, donc les touches sont compté comme non modifiées
            Settings.Save(); // sauvegarde après avoir récupéré les modifications
        }

        if (!Pause.Paused)
        {
            if (Input.GetKeyDown(gauche))//Appui sur <- 
            {
                move(-1, 0, 0); //Deplace a gauche
            }
            else if (Input.GetKeyDown(droite)) //Appui sur ->
            {
                move(1, 0, 0); //Deplace a droite
            }
            else if (Input.GetKeyDown(rotationD))//appui sur D
            {
                rotate(90);
            }
            else if (Input.GetKeyDown(rotaionG))//appui sur Q
            {
                rotate(-90);
            }

            else if (Time.time - previousTime > (Input.GetKey(bas) ? fallTime / 10 : fallTime))//Condition si on appuit sur bas ou que le temps de tombe arrive a zero
            {
                down();
                previousTime = Time.time;//remet de temps par defaut
            }

            else if (Input.GetKeyDown(basRapide))//Fait décendre le block le plus bas possible le plus rapidement
            {
                while (ValidMove())
                {
                    down();
                }
            }
        }


    }

    private SpawnTetrisBlock getBlock()
    {
        if (mainPlayer)
        {
            return FindObjectsOfType<SpawnTetrisBlock>()[0];
        }
        return FindObjectsOfType<SpawnTetrisBlock>()[1];
    }

    private void down()
    {
        transform.position += new Vector3(0, -1, 0);//Deplace vers le bas

        if (!ValidMove())
        {
            transform.position -= new Vector3(0, -1, 0);//si peut pas monte 
            AddToGrid();//regarde si il a un block
            CheckForLine();// Regarde si on peut supprimer une ligne
            this.enabled = false;//le bolck ne devient plus le block courant = desactiver
            getBlock().NewTetrisBlock();//Fait spawner un block
        }
    }

    private void move(int x, int y, int z)
    {
        transform.position += new Vector3(x, y, z); //Deplace
        if (!ValidMove())
            transform.position += new Vector3(-x, -y, -z); //Si peut pas, fait mouvement inverse
    }

    private void rotate(int r)
    {
        transform.RotateAround(transform.TransformPoint(RotationBlock), new Vector3(0, 0, 1), r);//Rotation du block a r° a droite
        if (!ValidMove())
            transform.RotateAround(transform.TransformPoint(RotationBlock), new Vector3(0, 0, 1), -r);//si peut pas r° a gauche
    }
    /**
        Fonction qui retourne la hauteur de la ligne la plus haute possédant au moins une parti d'un block déjà posé.
    */
    private int GetHighestLine()
    {

        for (int i = height - 1; i > 0; i--)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, i] != null)
                    return i;
            }
        }
        return 0;
    }

    /**
        Fonction qui verifie si une ligne est complete, si oui alors supprime la ligne, decsend les autres et ajoute du score
*/
    void CheckForLine()
    {
        int a = 0;

        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
                a++;
            }
        }

        Score.addScore(a);

    }

    /**
        Fonction qui retourne un boolean, vrai si une ligne est complete sinon faux
*/
    bool HasLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (grid[j, i] == null)
                return false;
        }
        return true;
    }

    /**
    *   Fonction permetant de supprimer les lignes complete
*/
    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);//Pas besoin de dire ce que ça fait non ?
            grid[j, i] = null;
        }


    }

    /**
        Foncion qui fait descendre toute les ligne audessus de celle supprimer
*/
    void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y]; //Remplace la ligne endessous par la courante
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0); // Deplace la ligne du dessous en haut
                }
            }
        }
    }

    /**
       Fonction qui permet d'ajouter a une matrix la position des blocks pour afin d'avoir des colision entre les blocks 
    */
    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);//Recupere le x du block courant
            int roundedY = Mathf.RoundToInt(children.transform.position.y);//Recupere le y du block courant
            grid[roundedX, roundedY] = children;
        }
        if (this.GetHighestLine() >= height - 1)
        {
            PlayerPrefs.SetInt("Score", Score.score);
            PlayerPrefs.SetInt("HighBefore", HighScore.highBefore);
            Pause.QuitGame2();
        }
    }

    /**
        Fonction permetent de delimiter la zone de jeu 20*10, retourne vrai si le mouvement du block et possible sinon faux
    */
    bool ValidMove()//Regarde si on peut faire un mouvement, ça utilise les cordonners des block 
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);//Recupere le x du block courant
            int roundedY = Mathf.RoundToInt(children.transform.position.y);//Recupere le y du block courant

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height) //Verifie si Longueur = 0<block<20 et Largeur = 0<block<10
            {
                return false;
            }
            if (grid[roundedX, roundedY] != null)//Verifi si a la position du mouvement il y a pas de block déja poser
                return false;
        }
        return true;
    }

    string endgame()
    {
        return " ";
    }
}
