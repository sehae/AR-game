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
        int lane = Random.Range(0, 3); // Select random lane: 0 = left, 1 = middle, 2 = right  to spawn
        Vector3 spawnPosition = new Vector3((lane - 1) * laneDistance, 0.27f, 10f); // Spawn at y = 0.27
        GameObject obstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPosition, Quaternion.Euler(0, 90, 0)); // Rotate 90 degrees around Y
        obstacle.transform.parent = transform; // Make the spawned obstacle a child of the spawner

        // Start a coroutine to destroy the obstacle when it reaches z = -5
        StartCoroutine(DestroyObstacleAfterTime(obstacle));
    }

    System.Collections.IEnumerator DestroyObstacleAfterTime(GameObject obstacle)
    {
        // Wait until the obstacle reaches z = -5 before destroying it (might be the console error)
        while (obstacle.transform.position.z > -5f)
        {
            yield return null; // Wait for the next frame
        }
        Destroy(obstacle);
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
            // Delete prefab once obj reaches z = -5
            Vector3 newPosition = child.position + Vector3.back * currentMoveSpeed * Time.deltaTime;

            // Update the child's position
            child.position = newPosition;

            // Optionally check if the obstacle is beyond z = -5 for destruction (eto ata ung console error)
            if (newPosition.z <= -5f)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
