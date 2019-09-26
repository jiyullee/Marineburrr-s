using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_CheckScore : MonoBehaviour
{ 
    public int increase;
    public int decrease;
    Dolphin_LevelManager dolphin_LevelManager;
    TutorialManager tutorialManager;
    GameObject service;
    private void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
        dolphin_LevelManager = service.GetComponent<Dolphin_LevelManager>();
        tutorialManager = service.GetComponent<TutorialManager>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Ring" && !tutorialManager.getIsChange())
        {           
            if (!collider.gameObject.GetComponent<Ring>().GetIsReach())
            {
                if(collider.gameObject.GetComponentInChildren<Dolphin_RIng_Back>().isPass)
                    dolphin_LevelManager.IncreaseScore(increase);
                           
            }              
            else{
                dolphin_LevelManager.DecreaseScore(decrease);
            }
               
        }
        if (collider.gameObject.tag == "Ring" && tutorialManager.getIsChange())
        {          
            dolphin_LevelManager.DecreaseScore(decrease);
        }
    }
}
