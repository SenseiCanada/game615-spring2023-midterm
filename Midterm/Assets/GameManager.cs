using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int score = 0;
    int enemyScore = 0;

    public TMP_Text scoreText;
    public TMP_Text enemyScoreText;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void IncrementEnemyScore()
    {
        enemyScore++;
        enemyScoreText.text = enemyScore.ToString();
    }
}
