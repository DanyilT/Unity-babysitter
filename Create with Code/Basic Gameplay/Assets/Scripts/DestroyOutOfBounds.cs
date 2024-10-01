using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy the object if it goes out of bounds
        if (transform.position.z > 30 || transform.position.z < -10)
        {
            Destroy(gameObject);
            // Game over if an animal goes out of bounds
            if (transform.position.z < -10)
            {
                Debug.Log("Game Over!");
            }
        }
    }
}
