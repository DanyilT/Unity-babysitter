using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Text scoreText; // UI Text to display the score
    [SerializeField] private Text turretsLeftText; // UI Text to display the number of turrets left
    private int score = 0;
    private int turretsLeft;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetTurretsLeft(int count)
    {
        turretsLeft = count;
        UpdateTurretsLeftText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void UpdateTurretsLeft(int change)
    {
        turretsLeft += change;
        UpdateTurretsLeftText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateTurretsLeftText()
    {
        turretsLeftText.text = "Turrets Left: " + turretsLeft;
    }
}
