using UnityEngine;

public class SpawnTetrisBlock : MonoBehaviour
{
    public GameObject[] Tetrominos;//Objet de type GameObject permetant de faire une liste de GameObject

    public GameObject[] Affichage_prochain;//Objet de type GameObject permetant de faire une liste de GameObject(La preview des block)

    public GameObject suiv; // bloc suivant
    public GameObject suiv2; // bloc après le bloc suivant

    private GameObject a; // valeur associée au bloc suivant (pour pouvoir le supprimer lorsqu'il sera obsolète)
    private GameObject b; // valeur associée au bloc suivant2 (pour pouvoir le supprimer lorsqu'il sera obsolète)

    private int valsuiv2; // valeur de l'index du 2eme bloc suivant
    private int valsuiv; // valeur de l'index du bloc suivant
    private int valactuel; // valeur de l'index du bloc actuel

    // initialisaton des positions des blocs suivants (nécéssaire pour instancier les blocs depuis le point ou ils sont)
    private Vector3 positionsuiv;
    private Vector3 positionsuiv2;
    
    [SerializeField] private GameObject spawn;



    private static SingletonBlock singleton;
    private static SingletonBlock singleton2;
    [SerializeField] private bool isFirst;

    // Start is called before the first frame update
    void Start()
    {
        if(singleton == null && isFirst){
            singleton = new SingletonBlock();
            // initialisation des premiers blocs a placer
            valsuiv2 = Random.Range(0, Tetrominos.Length);
            valsuiv = Random.Range(0, Tetrominos.Length);
            NewTetrisBlock();
            // initialiser aléatoirement ints qui définiront l'apparition des 2 tetrisblocks suivants  
            Vector3 positionsuiv = suiv.transform.position;
            /*Vector3 positionsuiv2 = suiv2.transform.position;*/
        }
        if(singleton2 == null && !isFirst){
            singleton2 = new SingletonBlock();
            NewTetrisBlock();
        }
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
        Destroy(a); //supprimer les blocs précédents (pour éviter qu'ils s'empilent les uns sur les autres)
        Destroy(b); //supprimer les blocs précédents (pour éviter qu'ils s'empilent les uns sur les autres)
        Instantiate(Tetrominos[valactuel], transform.position, Quaternion.identity);
        a = Instantiate(Affichage_prochain[valsuiv], suiv.transform.position, Quaternion.identity); // assigner le bloc suivant à a
        b = Instantiate(Affichage_prochain[valsuiv2], suiv2.transform.position, Quaternion.identity); // assigner le bloc suivant à b

    }
}
