using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    [SerializeField] private GameObject[] obstaclesPrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int obstacleIndex = Random.Range(0, obstaclesPrefab.Length);
            Instantiate(obstaclesPrefab[obstacleIndex], spawnPos, obstaclesPrefab[obstacleIndex].transform.rotation);
        }
    }
}
