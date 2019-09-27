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
    bool isCrash;

    private void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
        dolphin_LevelManager = service.GetComponent<Dolphin_LevelManager>();
        tutorialManager = service.GetComponent<TutorialManager>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ring" && !tutorialManager.getIsChange())
        {
            if (!collider.gameObject.GetComponent<Ring>().GetIsReach())
            {
                if (collider.gameObject.GetComponentInChildren<Dolphin_RIng_Back>().getIsPass())
                {
                    if (!collider.gameObject.GetComponent<Ring>().getIsScore())
                    {
                        collider.gameObject.GetComponent<Ring>().setIsScore(true);
                        collider.gameObject.GetComponent<Ring>().setIsDownScore(true);
                        dolphin_LevelManager.IncreaseScore(increase);
                    }
                }


            }
            else
            {
                if (!collider.gameObject.GetComponent<Ring>().getIsDownScore())
                {
                    collider.gameObject.GetComponent<Ring>().setIsScore(true);
                    collider.gameObject.GetComponent<Ring>().setIsDownScore(true);
                    dolphin_LevelManager.DecreaseScore(decrease);
                }

            }

        }
        if (collider.gameObject.tag == "Ring" && tutorialManager.getIsChange())
        {
            if (!collider.gameObject.GetComponent<Ring>().getIsDownScore())
            {
                collider.gameObject.GetComponent<Ring>().setIsScore(true);
                collider.gameObject.GetComponent<Ring>().setIsDownScore(true);
                dolphin_LevelManager.DecreaseScore(decrease);
            }
            isCrash = true;
        }
    }
    public bool getIsCrash()
    {
        return isCrash;
    }
}
