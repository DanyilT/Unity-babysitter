using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text BestScoreText;
    public InputField NameInputField;
    public Button StartButton;
    public Button QuitButton;

    MenuManager menuManager;

    private void Start()
    {
        // Set up button listeners
        StartButton.onClick.AddListener(OnStartButtonClicked);
        QuitButton.onClick.AddListener(OnQuitButtonClicked);

        // Load and display the best score
        menuManager = FindObjectOfType<MenuManager>();
        if (menuManager != null)
        {
            BestScoreText.text = $"Best Score: {menuManager.bestPlayerName} : {menuManager.bestScore}";
        }
    }

    private void OnStartButtonClicked()
    {
        if (menuManager != null)
        {
            menuManager.playerName = string.IsNullOrEmpty(NameInputField.text) ? "Guest" : NameInputField.text;
        }
        SceneManager.LoadScene("main");
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
