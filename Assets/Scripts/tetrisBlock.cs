using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class tetrisBlock : MonoBehaviour
{
    private float previousTime; 
    public float fallTime = 0.8f;//Temps pour la piece de tomber
    private static int height = 40; //Hauteur
    private static int width = 20; //Longueur

    private KeyCode gauche = KeyCode.LeftArrow; //Appui sur <- 
    private KeyCode droite = KeyCode.RightArrow;//Appui sur ->
    private KeyCode bas = KeyCode.DownArrow;
    private KeyCode rotationD = KeyCode.D;
    private KeyCode rotaionG = KeyCode.Q;

    private static Transform[,] grid = new Transform[width,height]; //Pour les collision entre les block

    public Vector3 RotationBlock; //Rotation
    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(gauche))//Appui sur <- 
        {
            transform.position += new Vector3(-1,0,0); //Deplace a gauche
           
            if(!ValidMove())
                transform.position -= new Vector3(-1,0,0); //Si peut pas deplace a droite (Annule le movement)

        }
        else  if(Input.GetKeyDown(droite)) //Appui sur ->
        {
            transform.position += new Vector3(1,0,0); //Deplace a droite
           
            if(!ValidMove())
                transform.position -= new Vector3(1,0,0);//Si peut pas deplace a gauche (Annule le movement)

        }
        else if(Input.GetKeyDown(rotationD))//appui sur D
        {
            transform.RotateAround(transform.TransformPoint(RotationBlock),new Vector3(0,0,1),90);//Rotation du block a 90° a droite
            if(!ValidMove())
                 transform.RotateAround(transform.TransformPoint(RotationBlock),new Vector3(0,0,1),-90);//si peut pas 90° a gauche

        }
         else if(Input.GetKeyDown(rotaionG))//appui sur Q
        {
            transform.RotateAround(transform.TransformPoint(RotationBlock),new Vector3(0,0,1),-90);//Rotation du block a 90° a gauche
            if(!ValidMove())
                 transform.RotateAround(transform.TransformPoint(RotationBlock),new Vector3(0,0,1),90);//si peut pas 90° a droite

        }

        if(Time.time - previousTime > (Input.GetKey(bas) ? fallTime / 10 : fallTime))//Condition si on appuit sur bas ou que le temps de tombe arrive a zero
        {
            transform.position += new Vector3(0,-1,0);//Deplace vers le bas

             if(!ValidMove())
             {
                transform.position -= new Vector3(0,-1,0);//si peut pas monte 
               AddToGrid();//regarde si il a un block
                this.enabled = false;//le bolck ne devient plus le block courant = desactiver
                FindObjectOfType<SpawnTetrisBlock>().NewTetrisBlock();//Fait spawner un block
             }
            previousTime = Time.time;//remet de temps par defaut
        }
    
    }

    void AddToGrid(){//Permet de regarder si il y a un block en dessous
         foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            grid[roundedX,roundedY] = children;
    }
    }
    bool ValidMove()//Regarde si on peut faire un mouvement, ça utilise les cordonners des block 
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY>=height)
            {
                return false;
            }
            if(grid[roundedX,roundedY] != null)
            return false;
        }
        return true;
    }
}
