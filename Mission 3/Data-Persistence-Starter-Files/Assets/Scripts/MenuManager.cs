using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    internal string playerName = "Guest";
    internal string bestPlayerName = "Guest";
    internal int bestScore = 0;

    private static MenuManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Load the best score when the game starts
        LoadBestScore();

        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Load the best score whenever a new scene is loaded
        LoadBestScore();
    }

    public void UpdateBestScore(int score)
    {
        if (score > bestScore)
        {
            bestScore = score;
            SaveBestScore();
        }
    }

    private void SaveBestScore()
    {
        BestScoreData data = new BestScoreData { name = playerName, score = bestScore };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }

    private void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/bestscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScoreData data = JsonUtility.FromJson<BestScoreData>(json);
            bestScore = data.score;
            bestPlayerName = data.name;
        }
    }

    [System.Serializable]
    private class BestScoreData
    {
        public string name;
        public int score;
    }
}
