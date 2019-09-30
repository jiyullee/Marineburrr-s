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
    Dolphin_EffectManager effectManager;
    private void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
        dolphin_LevelManager = service.GetComponent<Dolphin_LevelManager>();
        tutorialManager = service.GetComponent<TutorialManager>();
        effectManager = service.GetComponent<Dolphin_EffectManager>();
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
                        Instantiate(effectManager.GetRingPass_Effect(), transform.position - new Vector3(50,0,0), Quaternion.identity);
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
