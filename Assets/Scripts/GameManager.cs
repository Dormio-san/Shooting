using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject EnemyOnePrefab;
    public GameObject EnemyTwoPrefab;
    public GameObject CoinPrefab;
    public int score;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemyOne", 1.0f, 3.0f);
        InvokeRepeating("CreateEnemyTwo", 2.0f, 5.0f);
        InvokeRepeating("CreateCoin", 1.0f, 15.0f);
        score = 0;
        scoreText.text = "Score: " + score;
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
    void CreateCoin()
    {
        Instantiate(CoinPrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
    }

    public void EarnScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}