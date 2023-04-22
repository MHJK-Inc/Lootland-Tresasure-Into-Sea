using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSerpent : MonoBehaviour
{
    private int enemyCount = 0; // Keep track of enemy spawned

    private float spawnX = 5f;
    private float spawnY = 5f;

    [SerializeField] private GameObject enemyPrefab; // The prefab for the enemy
    [SerializeField] private float minEnemyDistance = 3f; // The minimum distance between enemies
    [SerializeField] private Vector2 spawnPosition; // The position where the enemies will spawn
    [SerializeField] private bool random; // Whether to spawn enemies at random positions
    [SerializeField] private float spawnInterval = 1f; // The time between enemy spawns
    [SerializeField] private int maxEnemyCount = 5; // The maximum number of enemies that can be in the scene
    public List<GameObject> enemyList = new List<GameObject>();
    private GameObject serpent;

    public int totalWeapons;

    private void Start()
    {
        totalWeapons = PlayerPrefs.GetInt("SpearGun") + PlayerPrefs.GetInt("Fireball") + PlayerPrefs.GetInt("Barrier");
        StartCoroutine(SpawnEnemies());
    }

    private void Update()
    {
    }

    private IEnumerator SpawnEnemies()
    {
        GameObject player = GameObject.Find("Player");
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval); // Wait for the spawn interval

            if (enemyCount < maxEnemyCount) // Check if we haven't reached the maximum enemy count
            {
                if (random) // Spawn at a random position
                {
                    // Get the player's position
                    Vector2 playerPosition = player.transform.position;

                    float x = Random.Range(playerPosition.x - spawnX, playerPosition.x + spawnX);
                    float y = Random.Range(playerPosition.y - spawnY, playerPosition.y + spawnY);
                    serpent = Instantiate(enemyPrefab, new Vector2(x, y), Quaternion.identity);
                    enemyList.Add(serpent);
                }
                else // Spawn at the specified position
                {
                    serpent = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                    enemyList.Add(serpent);
                }

                enemyCount++; // Increment the enemy count
            }
        }
    }

    // Method to be called when an enemy is destroyed
    public void EnemyDestroyed()
    {
        // Debug.Log("ENEMY COUNT:" + enemyCount);
        enemyList.Remove(serpent);
        enemyCount--;
    }
}
