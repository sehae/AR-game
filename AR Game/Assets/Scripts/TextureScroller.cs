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
        // Calculate the new texture offset
        float newOffsetX = Mathf.Repeat(Time.time * scrollSpeed, 1); // Scroll along the X-axis for rotated plane
        Vector2 newOffset = new Vector2(newOffsetX, savedOffset.y); // Use saved Y offset

        // Apply the new offset to the material
        planeRenderer.material.mainTextureOffset = newOffset;
    }

    void OnDisable()
    {
        // Reset the texture offset when the object is disabled
        planeRenderer.material.mainTextureOffset = savedOffset;
    }
}
