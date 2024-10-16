using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public Text scoreText;
    public GameOverUIManager gameOverUIManager; // Reference to the Game Over UI Manager
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
    if (scoreText != null)
    {
        if (!gameOver)
        {
            scoreText.text = "Score: " + score;
        }
    }
    else
    {
        Debug.LogError("scoreText is not assigned in the Inspector!");
    }
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
        gameOverUIManager.ShowGameOver(score); // Show the Game Over UI with the score
    }
}
