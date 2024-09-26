using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    public float laneDistance = 2f;
    private int currentLane = 1; // Start in the middle lane (0 = left, 1 = middle, 2 = right)

    void Update()
    {
        
        // Lane change controls
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--;
            MoveToLane(currentLane);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
        {
            currentLane++;
            MoveToLane(currentLane);
        }
    }

    void MoveToLane(int lane)
    {
        float targetX = (lane - 1) * laneDistance;
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        transform.position = targetPosition;
    }

}
