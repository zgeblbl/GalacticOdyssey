using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int minNumAsteroids = 3; // Minimum number of asteroids to spawn
    public int maxNumAsteroids = 6; // Maximum number of asteroids to spawn
    public float minSpawnInterval = 1f; // Minimum time between spawns
    public float maxSpawnInterval = 3f; // Maximum time between spawns

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
        Vector3 spawnViewportPosition = new Vector3(Random.Range(3f, 10f), 1.2f, 0f); // Adjust the range as needed
        Vector3 spawnWorldPosition = Camera.main.ViewportToWorldPoint(spawnViewportPosition);
        spawnWorldPosition.z = 0f;

        GameObject asteroid = Instantiate(asteroidPrefab, spawnWorldPosition, Quaternion.identity);
        Asteroid asteroidScript = asteroid.GetComponent<Asteroid>();
        if (asteroidScript != null)
        {
            asteroidScript.InitializeAsteroid();
        }
    }

}
