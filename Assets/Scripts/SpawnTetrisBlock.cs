using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTetrisBlock : MonoBehaviour
{
    public GameObject[] Tetrominos;//Objet de type GameObject permetant de faire une liste de GameObject(Liste de block)

    public Sprite[] lib; // Initialiser les images a montrer

    public SpriteRenderer suiv; // image du bloc suivant
    public SpriteRenderer suiv2; // image bloc après le bloc suivant

    private int valsuiv2; // valeur de l'index du 2eme bloc suivant
    private int valsuiv; // valeur de l'index du bloc suivant
    private int valactuel; // valeur de l'index du bloc actuel


    // Start is called before the first frame update
    void Start()
    {
        // initialiser aléatoirement ints qui définiront l'apparition des 2 tetrisblocks suivants
        valsuiv2 = Random.Range(0, Tetrominos.Length);
        valsuiv = Random.Range(0, Tetrominos.Length);
        NewTetrisBlock();
        // initialisation des sprites (images)
        suiv.sprite = lib[valsuiv];
        suiv2.sprite = lib[valsuiv2];
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void NewTetrisBlock(){  //Fait apparaitre un nouveau block a l'endroit du gameObject
        // remplacer la valeur du bloc de n par celui de n+1
        valactuel = valsuiv;
        valsuiv = valsuiv2;
        valsuiv2 = Random.Range(0, Tetrominos.Length);
        /* afficher les blocs (on instancie le bloc en prenant la valeur généree aupravant, soit 
        Random.Range(0, Tetrominos.Length),
        qui est une fonction qui retourne un id aléatoire du groupe de blocs Tetrominos)*/
        // mettre a jour les sprites et le bloc courant
        Instantiate(Tetrominos[valactuel], transform.position, Quaternion.identity);
        suiv.sprite = lib[valsuiv];
        suiv2.sprite = lib[valsuiv2];
    }
}
