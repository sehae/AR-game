using UnityEngine;

public class CarController : MonoBehaviour
{
    public float carSpeed = 5f;
    public float maxPos = 2.8f;
    public float tiltSensitivity = 5f;
    public float planeWidth = 10f;
    public Transform planeTransform;
    Vector3 localPosition;
    public uiManager ui;  // Reference to uiManager

    void Start()
    {
        if (ui == null)
        {
            ui = GameObject.FindObjectOfType<uiManager>();
        }

        // Set the car as a child of the plane
        transform.SetParent(planeTransform, true);
        localPosition = transform.localPosition;
    }

    void Update()
    {
        // Use the y-axis of the accelerometer for portrait orientation
        float tiltInput = Input.acceleration.x * tiltSensitivity;
        
        // Update local position
        localPosition.x += tiltInput * carSpeed * Time.deltaTime;
        
        // Clamp position within the plane
        float halfPlaneWidth = planeWidth / 2f;
        localPosition.x = Mathf.Clamp(localPosition.x, -halfPlaneWidth, halfPlaneWidth);
        
        // Apply the local position
        transform.localPosition = localPosition;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            // Notify the uiManager to activate Game Over
            ui.gameOverActivated();

            // Optionally, destroy the car after showing the game over UI
            Destroy(gameObject);  // Destroy the car
        }
    }
}
