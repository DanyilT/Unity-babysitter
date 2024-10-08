using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    public Slider hungerSlider;
    [SerializeField] private int amountToBeFed;
    private int currentFedAmount = 0;
    private InterfaceManager interfaceScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hungerSlider.maxValue = amountToBeFed;
        hungerSlider.value = 0;
        hungerSlider.fillRect.gameObject.SetActive(false);

        // Find and assign the InterfaceManager script
        interfaceScript = GameObject.Find("Canvas").GetComponent<InterfaceManager>();
        if (interfaceScript == null)
        {
            Debug.LogError("InterfaceManager not found in the scene.");
        }
    }

    public void FeedAnimal(int amount)
    {
        currentFedAmount += amount;
        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = currentFedAmount;

        if (currentFedAmount >= amountToBeFed)
        {
            Destroy(gameObject, 0.1f);

            // Access the score variable from the Interface script
            if (interfaceScript != null)
            {
                interfaceScript.score++;
                Debug.Log("Score: " + interfaceScript.score);
            }
        }
    }
}
