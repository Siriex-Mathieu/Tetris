using UnityEngine;
using UnityEngine.SceneManagement;

public class waitingMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //Charger la scene n°1 => le jeu
            }
        
    }
}
