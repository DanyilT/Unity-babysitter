using UnityEngine;

public class SomethingIsHappeningThere : MonoBehaviour
{
    private PlayerController playerControllerScript;
    [SerializeField] private Camera rageCamera;
    [SerializeField] private Light mainLight;
    private string inputSequence = "";
    private const string targetSequence = "qwerty";
    private bool isInRage = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectInputSequence();
        MakePlayerInvincibleAndEnableDash();
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
                isInRage = !isInRage;
                inputSequence = "";
            }
        }
    }

    private void MakePlayerInvincibleAndEnableDash()
    {
        if (isInRage)
        {
            playerControllerScript.dash = true;
            playerControllerScript.gameOver = false;
            playerControllerScript.GetComponent<Animator>().SetBool("Death_b", false);
            mainLight.color = Color.red;
            rageCamera.gameObject.SetActive(true);

        }
        else
        {
            mainLight.color = Color.white;
            rageCamera.gameObject.SetActive(false);
        }
    }
}
