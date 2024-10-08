using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private InterfaceManager interfaceScript;
    private float topBound = 30;
    private float lowerBound = -10;
    private float horizontalBound = 30;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find and assign the InterfaceManager script
        interfaceScript = FindObjectOfType<InterfaceManager>();
        if (interfaceScript == null)
        {
            Debug.LogError("InterfaceManager not found in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy(Deactivate) the object if it goes out of bounds
        if (transform.position.z > topBound)
        {
            // Instead of destroying the projectile when it leaves the screen
            //Destroy(gameObject);

            // Just deactivate it
            gameObject.SetActive(false);
        }
        // Game over if an animal goes out of bounds
        else if (transform.position.z < lowerBound || transform.position.x < -horizontalBound || transform.position.x > horizontalBound)
        {
            if (interfaceScript != null)
            {
                interfaceScript.lives--;
                Debug.Log("Lives: " + interfaceScript.lives);
                Destroy(gameObject);
            }
        }
    }
}
