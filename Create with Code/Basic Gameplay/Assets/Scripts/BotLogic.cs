using System.Collections;
using UnityEngine;

public class BotLogic : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float objectLifetime = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnObjectsContinuously());
    }

    private IEnumerator SpawnObjectsContinuously()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnObject()
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        StartCoroutine(RemoveObjectAfterDelay(spawnedObject, objectLifetime));
    }

    private IEnumerator RemoveObjectAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
}
