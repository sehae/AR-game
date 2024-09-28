using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject car;
    public float maxPas = 2.7f;
    public float delayTimer = 1f;
    float timer;

    public uiManager ui;

    void Start() {
        timer = delayTimer;
    }

    void Update() {

        timer -= Time.deltaTime;

        // Adjust spawn rate based on score 
        delayTimer = Mathf.Max(0.3f, 1f - (ui.score / 100f * 0.1f));
        Debug.Log("Spawner Delay Timer: " + delayTimer);

        if (timer <=0) {
            Vector3 carPos = new Vector3 (Random.Range (-2.7f, 2.7f), transform.position.y, transform.position.z);
            Instantiate (car, carPos, transform.rotation);
            timer = delayTimer;
        }
    }
}
