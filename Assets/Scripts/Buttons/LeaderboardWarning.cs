using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardWarning : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool isUp = false;

    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(isUp){
            Activate();
        }
        else{
            Disable();
        }
    }

    public void Activate(){ // activer le menu de warning
        PauseMenuUI.SetActive(true);
        isUp = true;
    }

    public void Disable(){ // desactiver le menu de warning
        PauseMenuUI.SetActive(false);
        isUp = false;
    }
}
