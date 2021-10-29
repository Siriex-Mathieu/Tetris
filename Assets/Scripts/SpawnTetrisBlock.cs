using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTetrisBlock : MonoBehaviour
{
    public GameObject[] Tetrominos;//Objet de type GameObject permetant de faire une liste de GameObject(Liste de block)


    private static SpawnTetrisBlock singleton;

    // Start is called before the first frame update
    void Start()
    {
        if(singleton == null){
            singleton = new SpawnTetrisBlock();
            NewTetrisBlock();
        }
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void NewTetrisBlock(){//Fait apparaitre un nouveau block a l'endroit du gameObject
        Instantiate(Tetrominos[Random.Range(0, Tetrominos.Length)], transform.position, Quaternion.identity);
    }
}
