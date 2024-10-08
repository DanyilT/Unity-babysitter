using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject speed1;
    [SerializeField] private GameObject speed2;
    [SerializeField] private Button singlePlayerButton;
    [SerializeField] private Button multiPlayerButton;
    [SerializeField] private GameObject player1Car;
    [SerializeField] private GameObject player2Car;
    [SerializeField] private GameObject player1Camera;
    [SerializeField] private GameObject player2Camera;
    [SerializeField] private List<Camera> cameras;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Freeze the game
        Time.timeScale = 0;

        // Show the main menu
        mainMenuUI.SetActive(true);

        // Hide the speed section
        speed1.SetActive(false);
        speed2.SetActive(false);

        // Add listeners to the buttons
        singlePlayerButton.onClick.AddListener(OnSinglePlayerButtonPressed);
        multiPlayerButton.onClick.AddListener(OnMultiPlayerButtonPressed);
    }

    // Button event handlers
    private void OnSinglePlayerButtonPressed()
    {
        // Unfreeze the game
        Time.timeScale = 1;

        // Hide the main menu
        mainMenuUI.SetActive(false);
        speed1.SetActive(true);
        speed2.SetActive(false);

        // Enable Player 1 car and camera
        player1Car.SetActive(true);
        player1Camera.gameObject.SetActive(true);

        // Disable Player 2 car and camera
        player2Car.SetActive(false);
        player2Camera.gameObject.SetActive(false);
    }

    private void OnMultiPlayerButtonPressed()
    {
        // Unfreeze the game
        Time.timeScale = 1;

        // Hide the main menu
        mainMenuUI.SetActive(false);
        speed1.SetActive(true);
        speed2.SetActive(true);

        // Enable both Player 1 and Player 2 cars and cameras
        player1Car.transform.position = new Vector3(-4, player1Car.transform.position.y, 0);
        player1Car.SetActive(true);
        player1Camera.gameObject.SetActive(true);

        player2Car.transform.position = new Vector3(4, player2Car.transform.position.y, 0);
        player2Car.SetActive(true);
        player2Camera.gameObject.SetActive(true);

        // Set up split-screen view
        int i = 0;
        foreach (Camera camera in cameras)
        {
            if (i < 2)
            {
                camera.rect = new Rect(0, 0, 0.5f, 1);
            }
            else
            {
                camera.rect = new Rect(0.5f, 0, 0.5f, 1);
            }
            i++;
        }
    }

    // Restart function
    public void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
