using System.Collections.Generic;
using UnityEngine;

public class SomethingIsHappeningThere : MonoBehaviour
{
    [SerializeField] private GameObject planePrefab;
    [SerializeField] private Camera thirdPersonCamera;
    private string inputSequence = "";
    private const string targetSequence = "qwerty";

    // Update is called once per frame
    void Update()
    {
        DetectInputSequence();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            thirdPersonCamera.gameObject.SetActive(false);
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
                SpawnRandomPlanes();
                inputSequence = "";
            }
        }
    }

    private void SpawnRandomPlanes()
    {
        int numberOfPlanes = Random.Range(1, 1000);

        for (int i = 0; i < numberOfPlanes; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-100, 100),
                Random.Range(-100, 100),
                Random.Range(-100, 100)
            );

            Quaternion randomRotation = Quaternion.Euler(
                Random.Range(0f, 360f),
                Random.Range(0f, 360f),
                Random.Range(0f, 360f)
            );

            Instantiate(planePrefab, randomPosition, randomRotation);
        }

        thirdPersonCamera.gameObject.SetActive(true);
        StartCoroutine(DeactivateTargetCameraAfterDelay(5f));
    }

    private System.Collections.IEnumerator DeactivateTargetCameraAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        thirdPersonCamera.gameObject.SetActive(false);
    }
}
