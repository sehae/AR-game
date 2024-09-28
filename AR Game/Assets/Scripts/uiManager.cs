<<<<<<< Updated upstream
using System.Collections;
=======
using TMPro;
>>>>>>> Stashed changes
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
<<<<<<< Updated upstream
    public Text scoreText;  // UI Text that displays the score during the game
    public Text gameOverText;  // Text that shows "You Scored: *X* points" after game over
    public GameObject gameOverCanvas;  // The Game Over UI Canvas

    private bool gameOver;
=======
    public GameObject gameOverPanel;  // Reference to the Game Over UI panel
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;  // Reference to the final score text in Game Over panel
    bool gameOver;
>>>>>>> Stashed changes
    public int score;

    void Start()
    {
        gameOver = false;
        score = 0;
<<<<<<< Updated upstream
        gameOverCanvas.SetActive(false);  // Make sure the Game Over UI is hidden at the start
        InvokeRepeating("scoreUpdate", 1.0f, 0.1f);  // Call scoreUpdate every 0.1 seconds
=======
        InvokeRepeating("scoreUpdate", 1.0f, 0.1f);

        // Ensure the game over panel is hidden at the start
        gameOverPanel.SetActive(false);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        CancelInvoke("scoreUpdate");  // Stop the score from updating

        // Display the Game Over UI and the final score
        gameOverCanvas.SetActive(true);
        gameOverText.text = "You Scored: " + score + " points!";
=======

        // Show the game over panel and display the final score
        gameOverPanel.SetActive(true);
        finalScoreText.text = "You Scored: " + score + "points!";
>>>>>>> Stashed changes
    }
}
