using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float baseSpeed = 5f;  // Base speed of obstacles
    float speed;

    public uiManager ui;

    void Start()
    {
        speed = baseSpeed;
        ui = FindObjectOfType<uiManager>();
    }

    void Update()
    {
        // Increase the obstacle speed by score every 50 points
        speed = baseSpeed + (ui.score / 100f * 0.5f);  // Increase speed by 0.5f for every 50 points

        // Log the current speed for debugging
        Debug.Log("Obstacle Speed: " + speed);

        transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
    }
}
