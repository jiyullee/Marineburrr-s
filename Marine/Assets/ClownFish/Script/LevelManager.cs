using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject player;
    public Text scoreText;
    public int score;
    public int maxScore;

    private void Awake()
    {
        player = Instantiate(playerPrefab);
    }
    private void Update()
    {
        scoreText.text = score.ToString();
        if (score <= 0)
            score = 0; // 게임 오버
        if(score >= maxScore)
        {
            //게임 끝
        }
            
    }
}
