using UnityEngine;

public class TextureScroller : MonoBehaviour
{
    public float baseSpeed = 0.1f;  // Base speed for scrolling
    float speed;
    public uiManager ui;

    void Start()
    {
        speed = baseSpeed;
    }

    void Update()
    {
        // Increase road scroll speed by score every 50 points
        speed = baseSpeed + (ui.score / 100f * 0.05f);  // Increase scroll speed by 0.05f for every 50 points

        // Log the current speed for debugging
        Debug.Log("TextureScroller Speed: " + speed);

        Vector2 offset = new Vector2(0, Time.time * speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
