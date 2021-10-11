using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public GameObject ScoreText;
    Text txt;
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        txt = ScoreText.GetComponent<Text> ();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = score.ToString();
    }

   public static void addScore(int i)
    {
        if (i == 1)
            score += 40;
        if (i == 2)
            score += 100;
        if (i == 3)
            score += 300;
        if (i == 4)
            score += 1200;
    }

}
