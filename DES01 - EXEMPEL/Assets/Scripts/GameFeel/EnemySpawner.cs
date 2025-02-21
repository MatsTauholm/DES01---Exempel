using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public Transform spawnPoint;  // The location where enemies will spawn
    public int enemyCount = 7;    // Number of enemies to spawn
    public float spawnDelay = 1.0f; // Time delay between spawns

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            // Spawn the enemy at the spawn point
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // Wait for the specified delay
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
