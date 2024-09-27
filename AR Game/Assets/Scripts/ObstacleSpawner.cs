using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles; // Array of obstacle prefabs
    public float spawnInterval = 10f; // Interval between spawns
    public float laneDistance = 2f; // Distance between lanes
    public float initialMoveSpeed = 1f; // Initial speed at which obstacles move down
    public float acceleration = 0.1f; // Acceleration factor to increase speed over time
    private float currentMoveSpeed; // Current speed of obstacles

    void Start()
    {
        currentMoveSpeed = initialMoveSpeed; // Set the initial speed
        InvokeRepeating("SpawnObstacle", 0, spawnInterval);
    }

    void SpawnObstacle()
    {
        int lane = Random.Range(0, 3); // Select random lane: 0 = left, 1 = middle, 2 = right to spawn
        Vector3 spawnPosition = new Vector3((lane - 1) * laneDistance, 0.27f, 10f); // Spawn at y = 0.27
        GameObject obstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPosition, Quaternion.Euler(0, 90, 0)); // Rotate 90 degrees around Y
        obstacle.transform.parent = transform; // Make the spawned obstacle a child of the spawner

        // Ensure the obstacle has a collider (optional)
        if (obstacle.GetComponent<Collider>() == null)
        {
            // Add a Box Collider by default if no collider is present
            obstacle.AddComponent<BoxCollider>(); // Adjust to your preferred collider type
        }

        // Start a coroutine to destroy the obstacle when it reaches z = -5
        StartCoroutine(DestroyObstacleAfterTime(obstacle));
    }

    System.Collections.IEnumerator DestroyObstacleAfterTime(GameObject obstacle)
    {
        // Wait until the obstacle reaches z = -5 before destroying it
        while (obstacle != null && obstacle.transform.position.z > -5f)
        {
            yield return null; // Wait for the next frame
        }

        // Double-check to ensure the obstacle is still valid before destroying it
        if (obstacle != null)
        {
            Destroy(obstacle);
        }
    }

    void Update()
    {
        MoveObstacles();
        currentMoveSpeed += acceleration * Time.deltaTime; // Increase speed over time
    }

    void MoveObstacles()
    {
        // Move all spawned obstacles down the z-axis
        foreach (Transform child in transform)
        {
            if (child != null) // Check if child is not null
            {
                // Update the child's position
                Vector3 newPosition = child.position + Vector3.back * currentMoveSpeed * Time.deltaTime;
                child.position = newPosition;

                // Check if the obstacle is beyond z = -5 for destruction
                if (newPosition.z <= -5f)
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}
