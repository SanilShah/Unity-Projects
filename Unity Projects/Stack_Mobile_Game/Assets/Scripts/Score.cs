using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Track Score and High Score using PlayerPrefs.

public class Score : MonoBehaviour
{
    private int scoreInt = 0;
    private string score;
    private TextMeshProUGUI scoreUI;
    public TextMeshProUGUI highScoreUI;

    void Start()
    {
        highScoreUI = highScoreUI.GetComponent<TMPro.TextMeshProUGUI>();
        highScoreUI.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        ScoreUI();
       
    }

    private void Update()
    {
        if ( StackMovement.StackSpawned == true)
            ScoreUI();
    }

    private void AddHighScore()
    {
        if ( scoreInt > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", scoreInt);
            highScoreUI.text = score;
        }
        
    }

    private void ScoreUI()
    {   
        scoreInt = StackMovement.score;
        score = scoreInt.ToString();

        scoreUI = GetComponent<TMPro.TextMeshProUGUI>();
       

        scoreUI.text = score;
        AddHighScore();
        Debug.Log("ScoreUI:" + score);
        Debug.Log("HighScore:" + PlayerPrefs.GetInt("HighScore", 0));
    }
}
