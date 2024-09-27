using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    public float laneDistance = 2f; // Distance between lanes
    private int currentLane = 1;    // Start in the middle lane (0 = left, 1 = middle, 2 = right)
    private float laneChangeSpeed = 5f; // Speed of lane change
    private Vector3 targetPosition; // The position the car is moving towards

    void Start()
    {
        // Set the initial target position to the car's current position
        targetPosition = transform.position;
    }

    void Update()
    {
        // Handle lane change controls
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--;
            UpdateTargetPosition(currentLane);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
        {
            currentLane++;
            UpdateTargetPosition(currentLane);
        }

        // Smoothly move the car towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * laneChangeSpeed);
    }

    // Updates the target position based on the current lane
    void UpdateTargetPosition(int lane)
    {
        float targetX = (lane - 1) * laneDistance; // Calculate the x position based on the lane
        targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
    }
}
