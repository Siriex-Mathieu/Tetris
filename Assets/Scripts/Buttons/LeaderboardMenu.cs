using UnityEngine.SceneManagement;
using UnityEngine;

public class LeaderboardMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMain(){
        SceneManager.LoadScene("StartMenu"); // renvoie à la scene du menu
    }

    public void GoToLeaderboard(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +3); // renvoie à la scene du leaderboard
    }
}
