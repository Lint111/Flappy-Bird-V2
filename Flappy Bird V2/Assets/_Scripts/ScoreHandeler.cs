using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class ScoreHandeler : MonoBehaviour
{     
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int scoreIncrement=1;
    private int score = 0;  

    public void AddScore()
    {
        score+=scoreIncrement;
        scoreText.text= $"Score: {score}";
    }
    public int getScore()
    {
        return score;
    }
}
