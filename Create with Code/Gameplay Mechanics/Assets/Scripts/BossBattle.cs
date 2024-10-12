using UnityEngine;

public class BossBattle : MonoBehaviour
{
    private SpawnManager spawnManager;
    private float spawnInterval = 3.0f;
    private int maxWaves = 5;
    private int currentWave = 0;
    private float timer = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && currentWave < maxWaves)
        {
            SpawnMinions();
            timer = 0f;
            currentWave++;
        }
    }

    private void SpawnMinions()
    {
        spawnManager.SpawnEnemies(Random.Range(1, 4));
    }
}
