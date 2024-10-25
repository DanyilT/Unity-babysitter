using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; // The enemy prefab to spawn
    [SerializeField] private Transform[] spawnPoints; // Array of spawn points
    [SerializeField] private float initialSpawnInterval = 5.0f; // Initial spawn interval in seconds
    [SerializeField] private Slider spawnIntervalSlider; // Slider to adjust spawn interval

    private float spawnInterval;
    private float timeSinceLastSpawn;

    void Start()
    {
        spawnInterval = initialSpawnInterval;
        timeSinceLastSpawn = 0f;
        spawnIntervalSlider.value = initialSpawnInterval;
        spawnIntervalSlider.onValueChanged.AddListener(OnSpawnIntervalChanged);
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned.");
            return;
        }

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void OnSpawnIntervalChanged(float value)
    {
        spawnInterval = value;
        Debug.Log("Spawn interval changed to: " + spawnInterval);
    }
}
