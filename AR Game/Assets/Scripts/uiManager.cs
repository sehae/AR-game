using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public Text scoreText;  // UI Text that displays the score during the game
    public Text gameOverText;  // Text that shows "You Scored: *X* points" after game over
    public GameObject gameOverCanvas;  // The Game Over UI Canvas

    private bool gameOver;
    public int score;

    void Start()
    {
        gameOver = false;
        score = 0;
        gameOverCanvas.SetActive(false);  // Make sure the Game Over UI is hidden at the start
        InvokeRepeating("scoreUpdate", 1.0f, 0.1f);  // Call scoreUpdate every 0.1 seconds
    }

    void Update()
    {
        if (!gameOver)
        {
            scoreText.text = "Score: " + score;
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
        CancelInvoke("scoreUpdate");  // Stop the score from updating

        // Display the Game Over UI and the final score
        gameOverCanvas.SetActive(true);
        gameOverText.text = "You Scored: " + score + " points!";
    }
}
