using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemy;
    public float enemyDelay;
    public int[] weight;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int leftOrRight = Random.Range(0, 2);
            float xPos;
            float yPos;
            if(leftOrRight == 0)
            {
                xPos = -670.0f;
                yPos = Random.Range(-320.0f, 320.0f);
                GameObject temp = Instantiate(enemy[SelectEnemy()], new Vector3(xPos, yPos, 0), Quaternion.identity);
                temp.GetComponent<Enemy>().direction = true;
            }
            else
            {
                
                xPos = 670.0f;
                yPos = Random.Range(-320.0f, 320.0f);
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
    void Update()
    {
        
    }
}
