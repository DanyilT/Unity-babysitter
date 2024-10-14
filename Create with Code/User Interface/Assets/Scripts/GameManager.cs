using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject titleScreen;
    internal bool isGameActive;
    private bool isPaused = false;
    private int score = 0;
    private int lives = 3;
    private float spawnRate = 1.0f;

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(score);
        UpdateLives(0);
        titleScreen.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        spawnRate /= difficulty;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: \n" + score;
    }

    public void UpdateLives(int livesToTake = 1)
    {
        lives = lives - livesToTake <= 0 ? 0 : lives - livesToTake;
        livesText.text = "Lives: \n" + lives;
        if (lives == 0)
        {
            GameOver();
        }
    }

    public void PauseGame()
    {
        isPaused = !isPaused;
        pausePanel.gameObject.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
