using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    public float carSpeed;
    public float maxPos = 2.8f;

    Vector2 position;

    void Start()
    {
        position = transform.position;

    }

    void Update()
    {
        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, -2.7f, 2.7f);

        transform.position = position;
    }
}
