using UnityEngine;

public class CarCollider : MonoBehaviour
{
    // This method is called when the object first collides with another collider
    private void OnCollisionEnter(Collision collision)
    {
        // Log the name of the object this collider collided with
        Debug.Log("Collided with: " + collision.gameObject.name);

        // Check if the collided object is tagged as "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Example: Handle collision with an obstacle (e.g., destroy this game object)
            HandleObstacleCollision();
        }
    }

    // Method to handle obstacle collision
    private void HandleObstacleCollision()
    {
        // Optional: Add explosion effect, reduce health, or play a sound
        Debug.Log("Handling collision with obstacle...");

        // Destroy the car game object
        Destroy(gameObject);
    }

    // This method is called every frame while the object is in contact with another collider
    private void OnCollisionStay(Collision collision)
    {
        // Log the ongoing collision with the other object
        Debug.Log("Still colliding with: " + collision.gameObject.name);
    }

    // This method is called when the collision ends
    private void OnCollisionExit(Collision collision)
    {
        // Log the end of the collision with the other object
        Debug.Log("Stopped colliding with: " + collision.gameObject.name);
    }
}
