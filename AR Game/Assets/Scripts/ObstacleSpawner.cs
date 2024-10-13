using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles; // Array to hold different obstacle prefabs
    public float planeWidth = 10f;
    public float maxPas = 2.7f;
    public float delayTimer = 10f;
    public float obstacleSpeed = 5f; // New variable for obstacle speed
    float timer;

    public uiManager ui;
    public Transform planeTransform;
     public Vector3 carScale = new Vector3(1.5f, 1.5f, 1.5f); // New variable for car scale
    public float scaleVariation = 0f; // Variation in scale for some randomness


    void Start() {
        timer = delayTimer;
        // Set the spawner as a child of the plane
        transform.SetParent(planeTransform, true);
    }

    void Update() {
        timer -= Time.deltaTime;

        delayTimer = Mathf.Max(0.3f, 1f - (ui.score / 100f * 0.1f));
        Debug.Log("Spawner Delay Timer: " + delayTimer);

        if (timer <= 0)
        {
            SpawnObstacle();
            timer = delayTimer;
        }
    }

    void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstacles.Length);
        GameObject selectedObstacle = obstacles[randomIndex];

        float halfPlaneWidth = planeWidth / 2f;
        Vector3 spawnPos = new Vector3(
            Random.Range(-halfPlaneWidth, halfPlaneWidth),
            0,
            transform.localPosition.z
        );

        GameObject obstacle = Instantiate(selectedObstacle, planeTransform);
        obstacle.transform.localPosition = spawnPos;

        // Adjust the scale of the spawned obstacle
        float randomScale = Random.Range(1 - scaleVariation, 1 + scaleVariation);
        obstacle.transform.localScale = Vector3.Scale(carScale, new Vector3(randomScale, randomScale, randomScale));

        // Add ObstacleMovement component and set its speed
        ObstacleMovement movement = obstacle.AddComponent<ObstacleMovement>();
        movement.speed = obstacleSpeed;
    }
}

// New script for obstacle movement
public class ObstacleMovement : MonoBehaviour
{
    public float speed;

    void Update()
    {
        // Move the obstacle forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}