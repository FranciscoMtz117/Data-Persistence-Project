using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBestScore : MonoBehaviour
{
    public Text bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        //Load High Score
        GameManager.Instance.LoadHighScore();
        DisplayBestScore();
    }

    void DisplayBestScore()
    {
        bestScoreText.text = "Best Score: " + GameManager.Instance.highScoreName + ": " + GameManager.Instance.highScore;
    }
}
