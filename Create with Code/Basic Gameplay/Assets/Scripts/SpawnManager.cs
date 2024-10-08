using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnVectorPos = 30;
    private float xRange = 15;
    private float yRangeTop = 15;
    private float yRangeBottom = 5;
    private float startDelay = 2;
    private float spawnInterval = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int spawnAxisPos = Random.Range(0, 5);

        // Spawn animals at random positions
        if (spawnAxisPos == 0 || spawnAxisPos == 1 || spawnAxisPos == 2) // 60% chance of spawning on the x-axis
        {
            // Spawn on the x-axis
            Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), 0, spawnVectorPos);
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        }
        else if (spawnAxisPos == 3)
        {
            // Spawn on the left
            Vector3 spawnPos = new Vector3(-spawnVectorPos, 0, Random.Range(yRangeBottom, yRangeTop));
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, 90, 0));
        }
        else if (spawnAxisPos == 4)
        {
            // Spawn on the right
            Vector3 spawnPos = new Vector3(spawnVectorPos, 0, Random.Range(yRangeBottom, yRangeTop));
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, -90, 0));
        }
    }
}
