using UnityEngine;

public class SpawnTetrisBlock : MonoBehaviour
{
    public GameObject[] Tetrominos;//Objet de type GameObject permetant de faire une liste de GameObject(Liste de block)
    
    [SerializeField] private GameObject spawn;


    private static SingletonBlock singleton;
    private static SingletonBlock singleton2;
    [SerializeField] private bool isFirst;

    // Start is called before the first frame update
    void Start()
    {
        if(singleton == null && isFirst){
            singleton = new SingletonBlock();
            NewTetrisBlock();
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

    public void NewTetrisBlock(){//Fait apparaitre un nouveau block a l'endroit du gameObject
        print(spawn.transform.position.ToString());
        Instantiate(Tetrominos[Random.Range(0, Tetrominos.Length)], spawn.transform.position, Quaternion.identity);
    }
}
