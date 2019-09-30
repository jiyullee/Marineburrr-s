using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_Food_PassCheck : MonoBehaviour
{
    Feed food;
    bool isPass;
    Dolphin_LevelManager dolphin_LevelManager;
    GameObject service;
    TutorialManager tutorialManager;
    public int increase;
    bool isScored;
   
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        service = GameObject.FindGameObjectWithTag("Service");
        tutorialManager = service.GetComponent<TutorialManager>();
        food = GetComponentInParent<Feed>();
        dolphin_LevelManager = service.GetComponent<Dolphin_LevelManager>();
    }
    private void Update()
    {
        if (!food.getIsCrash())
            isPass = true;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (tutorialManager.getIsChange())
        {
            if (collider.tag == "Player")
            {
                if (isPass && !isScored && !food.getIsDownScore())
                {
                    dolphin_LevelManager.IncreaseScore(increase);
                    isScored = true;
                }

            }
        }
         
    }
}
