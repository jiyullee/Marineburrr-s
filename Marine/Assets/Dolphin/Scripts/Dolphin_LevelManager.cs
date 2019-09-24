using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dolphin_LevelManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerPrefab;
    public GameObject ringPrefab;
    float xPos = 500.0f;
    float[] yPos = { 500.0f, 600.0f };
    public float ringDelay;
    public int score;
    int maxScore = 100;
    public Text textScore;
    Main main;
    private void Start()
    {
        StartCoroutine(SpawnRing());
    }
    void Awake()
    {
        main = GameObject.FindGameObjectWithTag("Main").GetComponent<Main>();
        player = Instantiate(playerPrefab);
    }

    
    IEnumerator SpawnRing()
    {
        while (true)
        {
            int rand = Random.Range(0, 101);
            if(rand <= 100)
            {
                int randYpos = Random.Range(0, 2);
                if(randYpos == 0)
                     Instantiate(ringPrefab, new Vector3(xPos, yPos[0], 0), Quaternion.identity);
                else
                    Instantiate(ringPrefab, new Vector3(xPos, yPos[1], 0), Quaternion.identity);
                xPos -= 400;
            }
            yield return new WaitForSeconds(ringDelay);
        }
    }
    private void Update()
    {
        if (score <= 0)
            score = 0;
        if (score >= maxScore)
        {
            score = maxScore;
            if(main.level == 1)
                main.levelUp();
            main.LoadScene();
        }
          
        textScore.text = score.ToString();
    }
    public void DecreaseScore(int n)
    {
        score -= n;
    }
    public void IncreaseScore(int n)
    {
        score += n;
    }
}
