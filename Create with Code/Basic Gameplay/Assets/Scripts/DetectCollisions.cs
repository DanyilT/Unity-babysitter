using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private InterfaceManager interfaceScript;
    private AnimalHunger animalHungerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find and assign the InterfaceManager script
        interfaceScript = FindObjectOfType<InterfaceManager>();
        if (interfaceScript == null)
        {
            Debug.LogError("InterfaceManager not found in the scene.");
        }

        // Find and assign the AnimalHunger script
        animalHungerScript = gameObject.GetComponent<AnimalHunger>();
        if (animalHungerScript == null)
        {
            Debug.LogError("AnimalHunger not found in the scene.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            // Instead of destroying the projectile when it collides with an animal
            //Destroy(other.gameObject); 
            // Just deactivate the food and destroy the animal
            other.gameObject.SetActive(false);

            animalHungerScript.FeedAnimal(1);
        }
        else
        {
            Destroy(gameObject);

            // Access the lives variable from the Interface script
            if (interfaceScript != null)
            {
                interfaceScript.lives--;
                Debug.Log("Lives: " + interfaceScript.lives);
            }
        }
    }
}
