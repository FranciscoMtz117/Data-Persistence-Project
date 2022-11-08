using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    public int score;

    public int highScore = 0;
    public string highScoreName = "" ;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    public void GetPlayerName(string inputPlayerName)
    {
        playerName = inputPlayerName;

        Debug.Log(playerName);
    }

    [System.Serializable]
    public class SaveData
    {
        public int highScore;
        public string highScoreName;
    }

    public void SaveHighScore(int currentScore, string playerName)
    {
        SaveData data = new SaveData();

        data.highScore = currentScore;
        data.highScoreName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }


}
