using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    public GameObject[] enemy;
    List<GameObject> rightSpawnPointList = new List<GameObject>();
    List<GameObject> leftSpawnPointList = new List<GameObject>();
    int spRand;
    int enemyRand;
    float delay = 5.0f;
    private void Start()
    {
        StartCoroutine(Spawn());
    }
    private void Awake()
    {
        LeftSpawnPoint[] leftSpawnPoint = GetComponentsInChildren<LeftSpawnPoint>();
        RightSpawnPoint[] rightSpawnPoint = GetComponentsInChildren<RightSpawnPoint>();

        foreach (var sp in leftSpawnPoint)
        {
            leftSpawnPointList.Add(sp.gameObject);
        }
        foreach (var sp in rightSpawnPoint)
        {
            rightSpawnPointList.Add(sp.gameObject);
        }
    }

    IEnumerator Spawn()
    {
        while (true)
        { 
            int spRand = Random.Range(0, rightSpawnPointList.Count);
            int enemyRand = Random.Range(0, enemy.Length);
            GameObject temp1 = Instantiate(enemy[enemyRand], rightSpawnPointList[spRand].transform.transform.position, Quaternion.identity);
            temp1.GetComponent<Enemy>().direction = -1;

            spRand = Random.Range(0, leftSpawnPointList.Count);
            enemyRand = Random.Range(0, enemy.Length);
            GameObject temp2 = Instantiate(enemy[enemyRand], leftSpawnPointList[spRand].transform.transform.position, Quaternion.identity);
            temp2.GetComponent<Enemy>().direction = 1;
            yield return new WaitForSeconds(delay);
        }
        
        
    }
    

}
