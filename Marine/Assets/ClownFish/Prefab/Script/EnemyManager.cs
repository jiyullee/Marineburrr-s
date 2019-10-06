using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemy;
    public float enemyDelay;
    public int[] weight;
    Fish_TutorialManager fish_TutorialManager;
    void Start()
    {
        fish_TutorialManager = GetComponent<Fish_TutorialManager>();
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (fish_TutorialManager.isGameOver)
                break;
            int leftOrRight = Random.Range(0, 2);
            float xPos;
            float yPos;
            if(leftOrRight == 0)
            {
                xPos = 0;
                yPos = Random.Range(0, 720.0f);
                GameObject temp = Instantiate(enemy[SelectEnemy()], new Vector3(xPos, yPos, 0), Quaternion.identity);
                temp.GetComponent<Enemy>().direction = true;
            }
            else
            {
                
                xPos = 1280.0f;
                yPos = Random.Range(0, 720.0f);
                GameObject temp = Instantiate(enemy[SelectEnemy()], new Vector3(xPos, yPos, 0), Quaternion.identity);
                temp.GetComponent<Enemy>().direction = false;
            }
           
            yield return new WaitForSeconds(enemyDelay);
        }
    }
    
    int SelectEnemy()
    {
        int sum = 0;
        int rand = Random.Range(0, 101);
        int i = 0;
        while (true)
        {
            sum += weight[i];
            if(rand <= sum)
            {
                
                return i;
            }
            i++;
        }
    }
   
}
