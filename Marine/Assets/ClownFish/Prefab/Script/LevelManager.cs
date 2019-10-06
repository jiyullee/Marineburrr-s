using System.Collections;
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
    public Text scoreText;
    float time = 0;
    SoundManager soundManager;
    void Start()
    {
        soundManager = GetComponentInChildren<SoundManager>();
        StartCoroutine(SpawnFood());
    }

    private void Awake()
    {
        player = Instantiate(playerPrefab);
    }
    void Update()
    {      
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
                float xPos = Random.Range(0.0f,1280.0f);
                float yPos = Random.Range(0.0f, 720.0f);
                Instantiate(food, new Vector3(xPos, yPos, 0), Quaternion.identity);
            }
          
            yield return new WaitForSeconds(foodDelay);
        }
    }
    public void DecreaseScore(int n)
    {
        score -= n;
        soundManager.TurnOnMinusSound();
    }
    public void IncreaseScore(int n)
    {
        score += n;
        soundManager.TurnOnPlusSound();
    }
    public int GetScore()
    {
        return score;
    }
}
