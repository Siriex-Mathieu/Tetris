using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suivController : MonoBehaviour
{

    public GameObject suiv;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(getPosition());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getPosition(){
        return transform.position;
    }
}
