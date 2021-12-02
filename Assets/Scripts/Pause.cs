using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private bool isPaused;

    public static bool Paused = false;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            ActiveMenu();
        }
        else
        {
            DesactiveMenu();
        }
    }

    public void ActiveMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        PauseMenuUI.SetActive(true);
        Paused = true;
    }

   public void DesactiveMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        PauseMenuUI.SetActive(false);
        isPaused = false;
        Paused = false;
    }

    public static void pause(){
        Paused = true;
    }

    public static void unpause(){
        Paused = false;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("StartMenu");
        try
        {
            FindObjectsOfType<SpawnTetrisBlock>()[0].end();
        }
        catch (System.Exception)
        {
            
        }
        try{
            FindObjectsOfType<SpawnTetrisBlock>()[1].end();
        }catch{
            
        }

    }

    public static void QuitGame2()
    {
        SceneManager.LoadScene("StartMenu");
        try
        {
            FindObjectsOfType<SpawnTetrisBlock>()[0].end();
        }
        catch (System.Exception)
        {
            
        }
        try{
            FindObjectsOfType<SpawnTetrisBlock>()[1].end();
        }catch{
            
        }
    }
}
