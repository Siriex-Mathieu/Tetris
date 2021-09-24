using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class tetrisBlock : MonoBehaviour
{
    private float previousTime;
    public float fallTime = 0.8f;
    private static int height = 40;
    private static int width = 20;

    private static Transform[,] grid = new Transform[width,height];

    public Vector3 RotationBlock;
    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1,0,0);
           
            if(!ValidMove())
                transform.position -= new Vector3(-1,0,0);

        }
        else  if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1,0,0);
           
            if(!ValidMove())
                transform.position -= new Vector3(1,0,0);

        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(RotationBlock),new Vector3(0,0,1),90);
            if(!ValidMove())
                 transform.RotateAround(transform.TransformPoint(RotationBlock),new Vector3(0,0,1),-90);

        }

        if(Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0,-1,0);
             if(!ValidMove())
             {
                transform.position -= new Vector3(0,-1,0);
               AddToGrid();
                this.enabled = false;
                FindObjectOfType<SpawnTetrisBlock>().NewTetrisBlock();
             }
            previousTime = Time.time;
        }
    
    }

    void AddToGrid(){
         foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            grid[roundedX,roundedY] = children;
    }
    }
    bool ValidMove()
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
