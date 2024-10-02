using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    private GameManagerX gameManagerX;

    public TextMeshProUGUI timeText; // Reference to the UI Text component
    private float timeLeft = 60f; // Countdown starts from 60 seconds

    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
    }
    
    void Update()
    {
        if (gameManagerX.isGameActive)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timeText.text = "Time: " + Mathf.Round(timeLeft).ToString();
            }
            else
            {
                timeLeft = 0;
                timeText.text = "Time: 0";
                gameManagerX.GameOver();
            }
        }
    }
}
