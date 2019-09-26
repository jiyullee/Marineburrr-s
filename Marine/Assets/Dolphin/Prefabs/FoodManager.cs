﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject[] feed;
    public float feedDelay;
    GameObject player;
    int feedProperty = 70;
    TutorialManager tutorialManager;
    public List<GameObject> feedList = new List<GameObject>();
    void Start()
    {
        tutorialManager = GetComponent<TutorialManager>();
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
            if(rand <= feedProperty)
            {
                GameObject temp = Instantiate(feed[Random.Range(0, 2)], new Vector3(xPos, yPos, 0), Quaternion.identity);
                feedList.Add(temp);
            }
                
            yield return new WaitForSeconds(feedDelay);
            if (tutorialManager.getIsChange())
            {
                xPos -= 1000.0f;               
            }
            else
                xPos -= 300.0f;


        }
    }
}
