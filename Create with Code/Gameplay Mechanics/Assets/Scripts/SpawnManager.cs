using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesPrefab;
    public GameObject[] powerupsPrefab;
    private float spawnRange = 9.0f;
    internal int waveNumber = 1;
    private int enemyCount;
    private bool gameStarted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartGame();
    }

    internal void StartGame()
    {
        gameStarted = true;
        waveNumber = 1;
        SpawnEnemyWave();
        SpawnPowerup();
    }

    void Update()
    {
        if (!gameStarted) return;

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave();
            SpawnPowerup();
        }
    }

    private void SpawnEnemyWave()
    {
        if (waveNumber % 5 == 0)
        {
            SpawnBoss();
        }
        else
        {
            SpawnEnemies(waveNumber);
        }
    }

    private void SpawnBoss()
    {
        // Looking for Boss prefab in the enemiesPrefab array and instantiating it
        foreach (GameObject enemy in enemiesPrefab)
        {
            if (enemy.name.Contains("Boss"))
            {
                Instantiate(enemy, GenerateSpawnPosition(), enemy.transform.rotation);
                break;
            }
        }
    }

    internal void SpawnEnemies(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            bool spawnBigBob = Random.Range(0, 2) == 0 && enemiesToSpawn - i > 1;

            if (spawnBigBob)
            {
                Instantiate(enemiesPrefab[1], GenerateSpawnPosition(), enemiesPrefab[1].transform.rotation);
                i++; // Big Bob takes 2 slots (one added here and one in the for loop)
            }
            else
            {
                Instantiate(enemiesPrefab[0], GenerateSpawnPosition(), enemiesPrefab[0].transform.rotation);
            }
        }
    }

    private void SpawnPowerup(int powerupsToSpawn = 1)
    {
        for (int i = 0; i < powerupsToSpawn; i++)
        {
            Instantiate(powerupsPrefab[Random.Range(0, powerupsPrefab.Length)], GenerateSpawnPosition(), Quaternion.identity);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}
