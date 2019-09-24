using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject food;
    public GameObject player;
    public GameObject playerPrefab;
    public Image pauseImage;
    public float foodDelay;
    public int score;
    int maxScore = 100;
    public Text scoreText;
    float time = 0;
    public bool bulletOn;
    Main main;
    
    void Start()
    {

        main = GameObject.FindGameObjectWithTag("Main").GetComponent<Main>();
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
            main.LoadScene();
        }
        if (score <= 0)
            score = 0;
        scoreText.text = score.ToString();
        time += Time.deltaTime;
        if(63.0f <=time && time <= 63.1f)
        {
            bulletOn = true;
            StartCoroutine(Pause());                    
        }
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

    IEnumerator Pause()
    {
        pauseImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        pauseImage.gameObject.SetActive(false);
    }
}
