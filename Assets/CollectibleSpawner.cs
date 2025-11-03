using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject[] collectiblePrefabs; // Assign your 3 prefabs: Collectible_Red, Collectible_Blue, Collectible_Yellow
    public float spawnInterval = 2f; // Time between spawns
    public Vector2 spawnArea = new Vector2(10f, 10f); // X and Z range for random spawn positions
    public float spawnHeight = 0.5f; // Height above ground (adjust to place on top, not in ground)

    void Start()
    {
        // Start spawning collectibles repeatedly
        InvokeRepeating("SpawnCollectible", 0f, spawnInterval);
    }

    void SpawnCollectible()
    {
        // Safety check: Ensure the array is not empty
        if (collectiblePrefabs == null || collectiblePrefabs.Length == 0)
        {
            Debug.LogError("Spawner: No collectible prefabs assigned! Please assign them in the Inspector.");
            return; // Stop spawning to avoid errors
        }

        // Choose a random prefab
        GameObject prefabToSpawn = collectiblePrefabs[Random.Range(0, collectiblePrefabs.Length)];

        // Generate random position (Y is now adjustable)
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            spawnHeight, // Raised above ground
            Random.Range(-spawnArea.y / 2, spawnArea.y / 2)
        );

        // Instantiate the collectible
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}