using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject car;
    public float maxPas = 2.7f;
    public float delayTimer = 1f;
    float timer;

    void Start() {
        timer = delayTimer;
    }

    void Update() {

        timer -= Time.deltaTime;
        if (timer <=0) {
            Vector3 carPos = new Vector3 (Random.Range (-2.7f, 2.7f), transform.position.y, transform.position.z);
        
            Instantiate (car, carPos, transform.rotation);
            timer = delayTimer;
        }
    }
}
