using UnityEngine;

public class TextureScroller : MonoBehaviour
{
    public float scrollSpeed = 0.5f; // Speed at which the texture scrolls
    private Renderer planeRenderer;
    private Vector2 savedOffset;

    void Start()
    {
        // Get the renderer component of the plane
        planeRenderer = GetComponent<Renderer>();

        // Save the initial offset of the texture
        savedOffset = planeRenderer.material.mainTextureOffset;
    }

    void Update()
    {
        // Calculate the new texture offset along the Y-axis
        float newOffsetY = Mathf.Repeat(Time.time * scrollSpeed, 1); // Scroll along the Y-axis
        Vector2 newOffset = new Vector2(savedOffset.x, newOffsetY); // Use saved X offset

        // Apply the new offset to the material
        planeRenderer.material.mainTextureOffset = newOffset;
    }

    void OnDisable()
    {
        // Reset the texture offset when the object is disabled
        planeRenderer.material.mainTextureOffset = savedOffset;
    }
}
