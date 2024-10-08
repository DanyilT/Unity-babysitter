using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private GameObject mainMenu;

    public int score = 0;
    public int lives = 3;
    public bool gameOver = false;

    void Awake()
    {
        // Ensure the game is paused initially
        Time.timeScale = 0;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Score: " + score);
        UpdateScoreText();

        Debug.Log("Lives: " + lives);
        UpdateLivesText();

        // Show the main menu initially

        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
        UpdateLivesText();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;
    }

    private void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over!");

        // Freeze the game
        Time.timeScale = 0;

        // Show the restart button
        mainMenu.gameObject.SetActive(true);
    }

    public void StartOrRestartGame()
    {
        // Unfreeze the game
        Time.timeScale = 1;

        // Hide the main menu
        mainMenu.SetActive(false);

        if (gameOver)
        {
            // Reload the current scene if the game is over
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
