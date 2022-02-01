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
        gameOverPanel.SetActive(false);
        //score = GameObject.Find("GameScore").GetComponent<TMP_Text>();
        scoreHandeler=GameObject.Find("Canvas").GetComponent<ScoreHandeler>();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        //score.text = $"Your Score is: {scoreHandeler.getScore()}";

        //UI animation.
    }
}
