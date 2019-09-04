using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float[] weight;
    public float enemyDelay;
    public GameObject[] enemy;
    private void Start()
    {
        StartCoroutine(MakeEnemy());
    }

    int SelectEnemy()
    {
        float sum = 0;
        int rand = Random.Range(0, 100);
        int i = 0;
        while (true)
        {
            
            sum += weight[i];
            if(sum >= rand)
            {
                return i;
            }
            i++;
        }
    }
    IEnumerator MakeEnemy()
    {
        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject temp = Instantiate(enemy[SelectEnemy()]);
                int rand = Random.Range(0, 2); // 0 = 왼쪽 1 = 오른쪽
                if (rand == 0)
                {
                    temp.GetComponent<Enemy>().direction = true;                
                    temp.transform.position = new Vector3(-620.0f, Random.Range(-400.0f, 200.0f),0);
                }
                else
                {
                    temp.GetComponent<Enemy>().direction = false;                   
                    temp.transform.position = new Vector3(620.0f, Random.Range(-400.0f, 200.0f), 0);
                }
            }
            yield return new WaitForSeconds(enemyDelay);
        }
      
    }


}
