using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int minNumAsteroids = 3;
    public int maxNumAsteroids = 6;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;

    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            int numAsteroids = Random.Range(minNumAsteroids, maxNumAsteroids + 1);
            for (int i = 0; i < numAsteroids; i++)
            {
                SpawnSingleAsteroid();
            }

            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnSingleAsteroid()
    {
        // Define the spawn position in viewport coordinates with a y-value outside of the camera view
        Vector3 spawnViewportPosition = new Vector3(Random.Range(0f, 1f), 1.2f, 0f); // Adjust the y-value (1.2f) as needed
                                                                                     // Convert the viewport position to world coordinates
        Vector3 spawnWorldPosition = Camera.main.ViewportToWorldPoint(spawnViewportPosition);
        // Set the z-coordinate to ensure the asteroid is at the same depth as other objects in the scene
        spawnWorldPosition.z = 0f;

        // Instantiate the asteroid at the calculated world position
        GameObject asteroid = Instantiate(asteroidPrefab, spawnWorldPosition, Quaternion.identity);
        // Initialize the asteroid script if available
        Asteroid asteroidScript = asteroid.GetComponent<Asteroid>();
        if (asteroidScript != null)
        {
            asteroidScript.InitializeAsteroid();
        }
    }


}
