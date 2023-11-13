using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EnemyOnePrefab;
    public GameObject EnemyTwoPrefab;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemyOne", 1.0f, 3.0f);
        InvokeRepeating("CreateEnemyTwo", 2.0f, 5.0f);
        score = 0;
        scoreText.text = "score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemyOne()
    {
        Instantiate(EnemyOnePrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
    }

    void CreateEnemyTwo()
    {
        Instantiate(EnemyTwoPrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
    }

    public void GameOver()
    {
        CancelInvoke();
    }

    public void EarnScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        scoreText.text = "score: " + score;
    }
}