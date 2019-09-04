using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject player;
    public GameObject food;
    public Text scoreText;
    public int score;
    public int maxScore;
    public float foodDelay;
    private void Start()
    {
        StartCoroutine(MakeFood());
    }

    IEnumerator MakeFood()
    {
        while (true)
        {

            for(int i = 0; i < 2; i++)
            {
                float xPos = Random.Range(-640.0f, 640.0f);
                float yPos = Random.Range(-360.0f, 360.0f);
                Instantiate(food, new Vector3(xPos, yPos, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(foodDelay);
        }
       
    }
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
