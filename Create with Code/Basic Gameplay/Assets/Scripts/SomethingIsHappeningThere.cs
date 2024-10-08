using UnityEngine;

public class SomethingIsHappeningThere : MonoBehaviour
{
    [SerializeField] private GameObject botPrefab;
    [SerializeField] private Camera mainCamera;
    private string inputSequence = "";
    private const string targetSequence = "qwerty";

    // Update is called once per frame
    void Update()
    {
        DetectInputSequence();
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
                SpawnBots();
                inputSequence = "";
            }
        }
    }

    private void SpawnBots()
    {
        int axisPosition = Random.Range(0, 3);

        if (axisPosition == 0) {
            for (int i = -16; i <= 16; i++)
            {
                Instantiate(botPrefab, new Vector3(i, 0, 0), botPrefab.transform.rotation);
            }
        }
        else if (axisPosition == 1)
        {
            for (int i = -15; i <= 15; i++)
            {
                Instantiate(botPrefab, new Vector3(i, 0, -1), botPrefab.transform.rotation);
            }
        }
        else if (axisPosition == 2)
        {
            for (float i = -16.5f; i <= 16.5f; i++)
            {
                Instantiate(botPrefab, new Vector3(i, 0, -3), botPrefab.transform.rotation);
            }
        }

        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y + 1, mainCamera.transform.position.z);

        StartCoroutine(DeactivateTargetCameraAfterDelay(0.5f));
    }

    private System.Collections.IEnumerator DeactivateTargetCameraAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y - 1, mainCamera.transform.position.z);
    }
}
