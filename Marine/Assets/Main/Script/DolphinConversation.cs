﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DolphinConversation : MonoBehaviour
{
    [SerializeField] Sprite[] Conversations;
    [SerializeField] GameObject background;
    [SerializeField] GameObject player;
    [SerializeField] AudioClip[] Sounds;
     GameObject mainSaver;
    int sceneNum = 0;

    void Start()
    {
        
        mainSaver = GameObject.FindGameObjectWithTag("Main");
        if(mainSaver.GetComponent<Main>().dolphin == true)
        {
            sceneNum = 7;
            GetComponent<AudioSource>().clip = Sounds[sceneNum];
            StartCoroutine(Play());
            mainSaver.GetComponent<Main>().dolphin = false;
        }
        else
        {
            GetComponent<AudioSource>().clip = Sounds[sceneNum];
            StartCoroutine(Play());
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().sprite = Conversations[sceneNum];
        GetComponent<AudioSource>().clip = Sounds[sceneNum];
    }


    public void Next()
    {
        if (sceneNum == 6)
        {
           
            mainSaver.GetComponent<Main>().SavePlayerPos(player.transform.position);
            SceneManager.LoadScene("Dolphin_LoadingScene 1");

        }
        else if (sceneNum == Conversations.Length - 1)
        {
            background.SetActive(false);
            sceneNum = 0;
            gameObject.SetActive(false);
            player.GetComponent<MainPlayerMove>().speed = player.GetComponent<MainPlayerMove>().originSpeed;
        }
        else
        {
            sceneNum += 1;
            StartCoroutine(Play());
                }

    }

    public void Before()
    {
        if (sceneNum > 0)
        {
            sceneNum -= 1;
        }
    }
    IEnumerator Play()
    {
        GetComponent<AudioSource>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<AudioSource>().enabled = true;
    }
}
