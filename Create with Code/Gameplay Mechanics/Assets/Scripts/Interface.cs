using System.Linq;
using TMPro;
using UnityEngine;

public class Interface : MonoBehaviour
{
    private PlayerController playerController;
    private SpawnManager spawnManager;
    private GameObject player;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TextMeshProUGUI tipsText;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI gameOverText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        Time.timeScale = 0;

        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Transform>().position.y < -10)
        {
            waveText.gameObject.SetActive(false);
            gameOverMenu.SetActive(true);
            Time.timeScale = 0;
        }

        UpdatePowerupTips();
        waveText.text = $"Wave: {spawnManager.waveNumber}";
        gameOverText.text = $"Final Wave: \n{spawnManager.waveNumber}";
    }

    private void UpdatePowerupTips()
    {
        if (playerController.hasStrengthPowerup)
        {
            tipsText.text = "Strength Powerup Active!";
        }
        else if (playerController.hasFirePowerup)
        {
            tipsText.text = "Fire Powerup Active!";
        }
        else if (playerController.hasSmashPowerup)
        {
            tipsText.text = "Smash Powerup Active!\n<press `Space`>";
        }
        else
        {
            tipsText.text = "";
        }
    }

    public void OnStartGameButtonClicked()
    {
        mainMenu.SetActive(false);
        spawnManager.StartGame();
        Time.timeScale = 1;
    }

    public void OnRestartButtonClicked()
    {
        waveText.gameObject.SetActive(true);
        gameOverMenu.SetActive(false);
        Time.timeScale = 1;
        spawnManager.waveNumber = 1;

        // Reset player position, rotation, and forces
        player.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        player.GetComponent<Transform>().rotation = Quaternion.identity;
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        playerRb.linearVelocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;

        // Clear existing enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        // Clear existing powerups
        GameObject[] powerups = GameObject.FindGameObjectsWithTag("Powerup");
        GameObject[] firePowerups = GameObject.FindGameObjectsWithTag("FirePowerup");
        GameObject[] smashPowerups = GameObject.FindGameObjectsWithTag("SmashPowerup");

        // Combine all powerups into a single array
        GameObject[] allPowerups = powerups.Concat(firePowerups).Concat(smashPowerups).ToArray();
        foreach (GameObject powerup in allPowerups)
        {
            Destroy(powerup);
        }

        // Restart the spawn manager
        spawnManager.StartGame();
    }
}
