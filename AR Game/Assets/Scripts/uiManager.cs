using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class uiManager : MonoBehaviour
{
    public Text scoreText;
    bool gameOver;
    public int score;

    void Start()
    {
        gameOver = false;
        score = 0;
        InvokeRepeating("scoreUpdate", 1.0f, 0.1f);
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    void scoreUpdate()
    {
        if (!gameOver)
        {
            score += 1;
        }
    }

    public void gameOverActivated()
    {
        gameOver = true;
    }
}
