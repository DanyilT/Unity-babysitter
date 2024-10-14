using System.Collections;
using UnityEngine;

public class SomethingIsHappeningThere : MonoBehaviour
{
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private ParticleSystem bombParticle;
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
                SpawnBomb();
                inputSequence = "";
            }
        }
    }

    private void SpawnBomb()
    {
        Vector3 centerScreen = new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane + 10.0f);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(centerScreen);
        GameObject bomb = Instantiate(bombPrefab, worldPosition, Quaternion.identity, transform); // Set the parent of the bomb to this game object
        StartCoroutine(AnimateBomb(bomb));
    }

    private IEnumerator AnimateBomb(GameObject bomb)
    {
        float duration = 2.0f;
        float elapsedTime = 0.0f;
        Vector3 originalScale = bomb.transform.localScale;
        Vector3 targetScale = originalScale * 5.0f;
        Quaternion originalRotation = bomb.transform.rotation;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / duration;

            // Scale the bomb
            bomb.transform.localScale = Vector3.Lerp(originalScale, targetScale, progress);

            // Rotate the bomb
            bomb.transform.Rotate(Vector3.up, 360 * Time.deltaTime);

            // Shake the bomb
            bomb.transform.position += Random.insideUnitSphere * 0.1f;

            yield return null;
        }

        // Play explosion particles
        for (int i = 0; i < Screen.width; i += 50)
        {
            for (int j = 0; j < Screen.height; j += 50)
            {
                Vector3 particlePosition = Camera.main.ScreenToWorldPoint(new Vector3(i, j, Camera.main.nearClipPlane + 5.0f));
                ParticleSystem particle = Instantiate(bombParticle, particlePosition, bombParticle.transform.rotation, transform); // Set the parent of the particle to this game object
                var mainModule = particle.main;
                mainModule.duration = 0.5f;
                particle.Play();
            }
        }

        // Destroy the bomb object
        Destroy(bomb);

        // Open the nuke
        DestroyAllObjects();
    }

    private void DestroyAllObjects()
    {
        GameObject[] objects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj != gameObject && obj.tag != "MainCamera" && obj.transform.parent != transform)
            {
                Destroy(obj);
            }
        }
    }
}
