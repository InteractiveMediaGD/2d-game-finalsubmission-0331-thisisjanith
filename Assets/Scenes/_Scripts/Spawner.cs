using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject enemyPrefab;
    public GameObject healthPackPrefab;
    public GameObject asteroidPrefab; // <--- NEW SLOT

    [Header("Settings")]
    public float spawnRate = 2f;
    private float nextSpawn = 0f;

    public float spawnX = 10f;
    public float maxY = 4f;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            SpawnObject();
            nextSpawn = Time.time + (spawnRate / DifficultyManager.globalSpeed);
        }
    }

    void SpawnObject()
    {
        float randomY = Random.Range(-maxY, maxY);
        Vector3 spawnPos = new Vector3(spawnX, randomY, 0);

        // Generate a random number between 0.0 and 1.0
        float chance = Random.value;

        // Logic:
        // 10% Chance -> Health Pack
        // 30% Chance -> Asteroid
        // 60% Chance -> Enemy Ship

        if (healthPackPrefab != null && chance < 0.1f)
        {
            Instantiate(healthPackPrefab, spawnPos, Quaternion.identity);
        }
        else if (asteroidPrefab != null && chance < 0.4f) // 0.1 to 0.4 is a 30% range
        {
            Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}