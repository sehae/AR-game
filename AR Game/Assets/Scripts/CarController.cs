using UnityEngine;

public class CarController : MonoBehaviour
{
    public float carSpeed;
    public float maxPos = 2.8f;
    Vector2 position;
    public uiManager ui;  // Reference to uiManager

    void Start()
    {
        if (ui == null)
        {
            ui = GameObject.FindObjectOfType<uiManager>();
        }

        position = transform.position;
    }

    void Update()
    {
        // Control car movement
        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, -2.7f, 2.7f);
        transform.position = position;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            // Notify the uiManager to activate Game Over
            ui.gameOverActivated();

            // Optionally, destroy the car after showing the game over UI
            Destroy(gameObject);  // Destroy the car
<<<<<<< Updated upstream
            ui.gameOverActivated();  // Notify the uiManager
            SceneManager.LoadScene("GameOver"); // Trigger game over scene
=======
>>>>>>> Stashed changes
        }
    }
}
