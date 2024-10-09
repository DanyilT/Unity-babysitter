using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private GameObject gameOverPanel;
    private GameObject scoreText;
    private GameObject restartButton;
    private bool isIntroFinished = false;
    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerControllerScript.gameOver = true;
        StartCoroutine(PlayIntro());

        scoreText = GameObject.Find("Score Text");
        restartButton = GameObject.Find("Restart Button");
        restartButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(RestartGame);
        gameOverPanel.SetActive(false);

        InvokeRepeating("UpdateScore", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        gameOverPanel.SetActive(playerControllerScript.gameOver && isIntroFinished);
    }

    public void RestartGame()
    {
        Physics.gravity /= 1.5f; // Reset gravity
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    void UpdateScore()
    {
        if (!playerControllerScript.gameOver)
        {
            score = playerControllerScript.dash ? score += 2 : score += 1;
            Debug.Log("Score: " + score);
            scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: \n" + score;
        }
    }

    IEnumerator PlayIntro()
    {
        Vector3 startPosition = new Vector3(-5, 0, 0);
        Vector3 endPosition = playerControllerScript.transform.position;
        float journeyLength = Vector3.Distance(startPosition, endPosition);
        float startTime = Time.time;

        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;

        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_f", 0.5f);

        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            playerControllerScript.transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
            yield return null;
        }

        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_f", 1.0f);
        playerControllerScript.gameOver = false;
        isIntroFinished = true;
    }
}
