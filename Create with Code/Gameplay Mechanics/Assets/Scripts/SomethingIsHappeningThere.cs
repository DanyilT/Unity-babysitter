using UnityEngine;

public class SomethingIsHappeningThere : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    private string inputSequence = "";
    private const string targetSequence = "qwerty";
    private float spawnPosition = 15.0f;
    private float spawnTimer = 0.0f;
    private bool isThatApocalypseLookLikeThis = false;

    // Update is called once per frame
    void Update()
    {
        DetectInputSequence();

        if (isThatApocalypseLookLikeThis)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= 0.1f)
            {
                spawnTimer = 0.0f;
                SpawnGroundPrefab();
            }
        }
    }

    private void DetectInputSequence()
    {
        foreach (char c in Input.inputString)
        {
            inputSequence += c;

            if (inputSequence.Length > targetSequence.Length)
            {
                inputSequence = inputSequence.Substring(inputSequence.Length - targetSequence.Length);
            }

            if (inputSequence == targetSequence)
            {
                isThatApocalypseLookLikeThis = !isThatApocalypseLookLikeThis;
                inputSequence = "";
            }
        }
    }

    private void SpawnGroundPrefab()
    {
        GameObject ground = Instantiate(groundPrefab, new Vector3(Random.Range(-spawnPosition, spawnPosition), spawnPosition + 5, Random.Range(-spawnPosition, spawnPosition)), Quaternion.identity);
        ground.transform.localScale = new Vector3(Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f));
        ground.AddComponent<Rigidbody>();
        ground.GetComponent<Rigidbody>().mass = 100000 * ground.transform.localScale.x * ground.transform.localScale.y * ground.transform.localScale.z;
        ground.GetComponent<Rigidbody>().AddForce(Vector3.down * 100000);
    }
}
