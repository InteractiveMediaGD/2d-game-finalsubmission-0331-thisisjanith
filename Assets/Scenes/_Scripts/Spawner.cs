using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject enemyPrefab;
    public GameObject healthPackPrefab;
    public GameObject asteroidPrefab;

    [Header("Obstacle Corridor Prefabs (add multiple for variety!)")]
    public GameObject[] obstaclePrefabs;  // Array - drag multiple prefabs here!

    [Header("Enemy/Asteroid Spawn Settings")]
    public float spawnRate = 2f;
    private float nextSpawn = 0f;

    [Header("Obstacle Corridor Settings")]
    public float corridorSpawnRate = 8f;
    public float corridorMinRate = 5f;
    private float nextCorridorSpawn = 0f;

    public float spawnX = 10f;
    public float maxY = 4f;

    void Start()
    {
        nextCorridorSpawn = Time.time + corridorSpawnRate;
    }

    void Update()
    {
        // Regular enemy/asteroid/health spawning
        if (Time.time > nextSpawn)
        {
            SpawnObject();
            nextSpawn = Time.time + (spawnRate / DifficultyManager.globalSpeed);
        }

        // Corridor obstacle spawning (separate timer)
        if (Time.time > nextCorridorSpawn && obstaclePrefabs.Length > 0)
        {
            SpawnCorridor();
            float currentRate = Mathf.Lerp(corridorSpawnRate, corridorMinRate,
                (DifficultyManager.globalSpeed - 1f) / 2f);
            nextCorridorSpawn = Time.time + currentRate;
        }
    }

    void SpawnObject()
    {
        float randomY = Random.Range(-maxY, maxY);
        Vector3 spawnPos = new Vector3(spawnX, randomY, 0);

        float chance = Random.value;

        if (healthPackPrefab != null && chance < 0.1f)
        {
            Instantiate(healthPackPrefab, spawnPos, Quaternion.identity);
        }
        else if (asteroidPrefab != null && chance < 0.4f)
        {
            Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }

    void SpawnCorridor()
    {
        // Pick a random corridor prefab from the array
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject chosenPrefab = obstaclePrefabs[randomIndex];

        // Always spawn at Y = 0 so walls fully cover the screen
        Vector3 spawnPos = new Vector3(spawnX + 2f, 0f, 0);
        Instantiate(chosenPrefab, spawnPos, Quaternion.identity);
    }
}