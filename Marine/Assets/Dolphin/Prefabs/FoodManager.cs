using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject[] feed;
    public float feedDelay;
    GameObject player;
    void Start()
    {
        StartCoroutine(SpawnFeed());
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    IEnumerator SpawnFeed()
    {
        float xPos = 300.0f;
        float yPos = 800.0f;

        while (true)
        {
            int rand = Random.Range(0, 101);
            if(rand <= 70)
                Instantiate(feed[Random.Range(0, 2)], new Vector3(xPos, yPos, 0), Quaternion.identity);
            yield return new WaitForSeconds(feedDelay);
            xPos -= 300.0f;
        }
    }
}
