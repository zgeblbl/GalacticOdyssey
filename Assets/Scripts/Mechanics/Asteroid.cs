using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 5f; // Speed of the asteroid
    public float rotationSpeed = 100f; // Rotation speed of the asteroid

    void Start()
    {
        // Set initial position to upper right corner of camera's view
        Vector3 spawnPosition = new Vector3(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), 0f);
        spawnPosition = Camera.main.ViewportToWorldPoint(spawnPosition);
        spawnPosition.z = 0f; // Ensure z position is 0 to avoid depth issues
        transform.position = spawnPosition;

    }

    void Update()
    {
        // Move the asteroid towards left-down
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Check if the asteroid is outside the camera's view
        if (!IsInView())
        {
            Destroy(gameObject);
        }
    }

    bool IsInView()
    {
        // Check if the asteroid's position is within the camera's view
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
    }
}
