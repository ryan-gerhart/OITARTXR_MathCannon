using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathVisualizer : MonoBehaviour
{
    // Reference to the prefab that will be spawned
    public GameObject pathPrefab;

    // Time interval between each spawn
    public float spawnInterval = 1.0f;

    // Minimum movement threshold to allow spawning (prevents too many objects from spawning when not moving)
    public float minMovementThreshold = 0.1f;

    // Internal timer to track spawn time
    private float timer = 0.0f;

    // Store the last position to compare movement
    private Vector3 lastPosition;

    void Start()
    {
        // Initialize lastPosition to the object's starting position
        lastPosition = transform.position;
    }

    void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if enough time has passed since the last spawn
        if (timer >= spawnInterval)
        {
            // Check if the object has moved enough to warrant a new spawn
            if (Vector3.Distance(transform.position, lastPosition) > minMovementThreshold)
            {
                // Spawn the prefab at the current position
                Instantiate(pathPrefab, transform.position, Quaternion.identity);

                // Update the last position
                lastPosition = transform.position;
            }

            // Reset the timer
            timer = 0.0f;
        }
    }
}
