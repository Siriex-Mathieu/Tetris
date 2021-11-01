using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTetrisBlock : MonoBehaviour
{
    public GameObject[] Tetrominos;//Objet de type GameObject permetant de faire une liste de GameObject(Liste de block)

    public GameObject suiv; // bloc suivant
    public GameObject suiv2; // bloc après le bloc suivant

    private int valsuiv2; // valeur de l'index du 2eme bloc suivant
    private int valsuiv; // valeur de l'index du bloc suivant
    private int valactuel; // valeur de l'index du bloc actuel

    // initialisaton des positions des blocs suivants (nécéssaire pour instancier les blocs depuis le point ou ils sont)
    private Vector3 positionsuiv;
    private Vector3 positionsuiv2;

    // Start is called before the first frame update
    void Start()
    {
        valsuiv2 = Random.Range(0, Tetrominos.Length);
        valsuiv = Random.Range(0, Tetrominos.Length);
        NewTetrisBlock();
        // initialiser aléatoirement ints qui définiront l'apparition des 2 tetrisblocks suivants  
        Vector3 positionsuiv = suiv.transform.position;
        /*Vector3 positionsuiv2 = suiv2.transform.position;*/
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void NewTetrisBlock(){  //Fait apparaitre un nouveau block a l'endroit du gameObject
        valactuel = valsuiv;
        valsuiv = valsuiv2;
        valsuiv2 = Random.Range(0, Tetrominos.Length);
        Instantiate(Tetrominos[valactuel], transform.position, Quaternion.identity);
        Instantiate(Tetrominos[valsuiv], suiv.transform.position, Quaternion.identity);
        Instantiate(Tetrominos[valsuiv2], suiv2.transform.position, Quaternion.identity);
        Debug.Log("valactuel =" + valactuel + "valsuiv =" + valsuiv + "valsuiv2 = " + valsuiv2);
        Debug.Log(suiv.transform.position);
    }
}
