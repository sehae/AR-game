using UnityEngine;
using UnityEngine.SceneManagement;  // For scene loading
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Button retryButton;      // Reference to the Retry Button
    public Button mainMenuButton;   // Reference to the Main Menu Button

    void Start()
    {
        // Assign the button listeners
        retryButton.onClick.AddListener(RetryGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    // Function to reload the current game scene
    void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reloads the current scene
    }

    // Function to load the Main Menu scene
    void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");  // Replace "MainMenu" with your actual main menu scene name
    }
}
