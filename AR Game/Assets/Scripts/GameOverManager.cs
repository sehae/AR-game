using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For loading scenes
using TMPro; // Import TextMesh Pro namespace

public class GameOverUIManager : MonoBehaviour
{
    public TMP_Text finalScoreText; // Reference to the score text UI element
    public GameObject gameOverPanel; // Reference to the Game Over panel
    public GameObject RetryButton;
    public GameObject MainMenubutton;

    void Start()
    {
        gameOverPanel.SetActive(false); // Hide the Game Over panel at the start
    }

    public void ShowGameOver(int score)
    {
        finalScoreText.text = "You got " + score + " points!"; // Display the final score
        gameOverPanel.SetActive(true); // Show the Game Over panel
    }

    public void Retry()
    {
        Debug.Log("Retry button clicked.");
        Debug.Log("Current Scene Index: " + SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        // Load the main menu scene (replace "MainMenu" with your actual menu scene name)
        SceneManager.LoadScene("MainMenu");
    }
}
