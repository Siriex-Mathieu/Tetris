using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class tetrisBlockJ2 : MonoBehaviour
{

    private float previousTime;
    public float fallTime = 0.8f;//Temps pour la piece de tomber
    private static int height = 20; //Hauteur
    private static int width = 30; //Longueur

    private KeyCode gauche = KeyCode.LeftArrow; //Appui sur <- 
    private KeyCode droite = KeyCode.RightArrow;//Appui sur ->
    private KeyCode bas = KeyCode.DownArrow;
    private KeyCode basRapide = KeyCode.RightControl;
    private KeyCode rotationD = KeyCode.L;
    private KeyCode rotaionG = KeyCode.M;

    private static Transform[,] grid = new Transform[width, height]; //Pour les collision entre les block

    public Vector3 RotationBlock; //Rotation
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // FindObjectsOfType<SpawnTetrisBlock>()[1].
        if (Input.GetKeyDown(gauche))//Appui sur <- 
        {
            transform.position += new Vector3(-1, 0, 0); //Deplace a gauche

            if (!ValidMove())
                transform.position -= new Vector3(-1, 0, 0); //Si peut pas deplace a droite (Annule le movement)

        }
        else if (Input.GetKeyDown(droite)) //Appui sur ->
        {
            transform.position += new Vector3(1, 0, 0); //Deplace a droite

            if (!ValidMove())
                transform.position -= new Vector3(1, 0, 0);//Si peut pas deplace a gauche (Annule le movement)

        }
        else if (Input.GetKeyDown(rotationD))//appui sur D
        {
            transform.RotateAround(transform.TransformPoint(RotationBlock), new Vector3(0, 0, 1), 90);//Rotation du block a 90° a droite
            if (!ValidMove())
                transform.RotateAround(transform.TransformPoint(RotationBlock), new Vector3(0, 0, 1), -90);//si peut pas 90° a gauche

        }
        else if (Input.GetKeyDown(rotaionG))//appui sur Q
        {
            transform.RotateAround(transform.TransformPoint(RotationBlock), new Vector3(0, 0, 1), -90);//Rotation du block a 90° a gauche
            if (!ValidMove())
                transform.RotateAround(transform.TransformPoint(RotationBlock), new Vector3(0, 0, 1), 90);//si peut pas 90° a droite

        }

        if (Time.time - previousTime > (Input.GetKey(bas) ? fallTime / 10 : fallTime))//Condition si on appuit sur bas ou que le temps de tombe arrive a zero
        {
            transform.position += new Vector3(0, -1, 0);//Deplace vers le bas

            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);//si peut pas monte 
                AddToGrid();//regarde si il a un block
                CheckForLine();// Regarde si on peut supprimer une ligne
                this.enabled = false;//le bolck ne devient plus le block courant = desactiver
                FindObjectsOfType<SpawnTetrisBlock>()[1].NewTetrisBlock();
            }
            previousTime = Time.time;//remet de temps par defaut
        }

        else if (Input.GetKeyDown(basRapide))//Fait décendre le block le plus bas possible le plus rapidement
        {
            while (ValidMove())
            {
                transform.position += new Vector3(0, -1, 0);//Deplace vers le bas

                if (!ValidMove())
                {
                    transform.position -= new Vector3(0, -1, 0);//si peut pas monte 
                    AddToGrid();//regarde si il a un block
                    CheckForLine();// Regarde si on peut supprimer une ligne
                    this.enabled = false;//le bolck ne devient plus le block courant = desactiver
                    FindObjectsOfType<SpawnTetrisBlock>()[1].NewTetrisBlock();
                }
            }
        }


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

    void CheckForLine()// Regarde si on peut supprimer une ligne
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

    bool HasLine(int i)//Verifie si une ligne est complete
    {
        for (int j = 0; j < width; j++)
        {
            if (grid[j, i] == null)
                return false;
        }
        return true;
    }

    void DeleteLine(int i)//Supprime la ligne
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }


    }

    void RowDown(int i)//Decend toutes les autre ligne
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    void AddToGrid()
    {//Permet de regarder si il y a un block en dessous
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            grid[roundedX, roundedY] = children;
        }
        if (this.GetHighestLine() >= height - 1)
        {
            print("game over");
            Pause.QuitGame2();
        }

    }
    bool ValidMove()//Regarde si on peut faire un mouvement, ça utilise les cordonners des block 
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if (roundedX < 20 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }
            if (grid[roundedX, roundedY] != null)
                return false;
        }
        return true;
    }
}
