using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // This method will be called when the start button is clicked
    public void StartGame()
    {
        // Replace "AR grp game" with the exact name of your game scene
        SceneManager.LoadScene("AR grp game");
    }
}
