using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private GameObject gameOverPanel;
    private TMP_Text score;
    private ScoreHandeler scoreHandeler;

    private void Start() {
        gameOverPanel = GameObject.Find("GameOverScreen");        
        score = GameObject.Find("GameScore").GetComponent<TMP_Text>();
        scoreHandeler=GameObject.Find("Canvas").GetComponent<ScoreHandeler>();
        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        int gameScore = scoreHandeler.getScore();
        score.text = $"Your Score is: {gameScore}";
        //UI animation.
    }
}
