using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    public Transform planeTransform;
    // Start is called before the first frame update
    void Start()
    {
        // Set the destroyer as a child of the plane
        transform.SetParent(planeTransform, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            Destroy(col.gameObject);
        }
    }
}
