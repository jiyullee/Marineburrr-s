﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject food;
    public GameObject player;
    public GameObject playerPrefab;
    public float foodDelay;
    public int score;
    int maxScore = 100;
    public Text scoreText;
    void Start()
    {

        StartCoroutine(SpawnFood());
    }

    private void Awake()
    {
        player = Instantiate(playerPrefab);
    }
    void Update()
    {
        if(score >= maxScore)
        {
            // 게임 오버
        }
        if (score <= 0)
            score = 0;
        scoreText.text = score.ToString();
        
    }

    IEnumerator SpawnFood()
    {
        while (true)
        {
            for(int i = 0; i < 3; i++)
            {
                float xPos = Random.Range(-640.0f, 640.0f);
                float yPos = Random.Range(-360.0f, 360.0f);
                Instantiate(food, new Vector3(xPos, yPos, 0), Quaternion.identity);
            }
          
            yield return new WaitForSeconds(foodDelay);
        }
    }
}
