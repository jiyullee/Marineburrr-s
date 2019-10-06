using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_PassCheck : MonoBehaviour
{
    Ring ring;
    Dolphin_RIng_Back ring_back;
    Dolphin_DecreaseScore ring_updown;
    Dolphin_LevelManager dolphin_LevelManager;
    bool isPass;
    bool isScored;
    public int increase;
    GameObject service;
    TutorialManager tutorialManager;
    GameObject player;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");              
        service = GameObject.FindGameObjectWithTag("Service");
        tutorialManager = service.GetComponent<TutorialManager>();
        ring = GetComponentInParent<Ring>();
        ring_back = ring.GetComponentInChildren<Dolphin_RIng_Back>();
        ring_updown = ring.GetComponentInChildren<Dolphin_DecreaseScore>();
        dolphin_LevelManager = service.GetComponent<Dolphin_LevelManager>();
       
    }
    private void Update()
    {
        if (!ring.getIsCrash() && !ring_back.getIsCrash() && !ring_updown.getIsCrash())
        {
            isPass = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (tutorialManager.getIsChange())
        {
            if (collider.tag == "Player")
            {
                if (isPass && !isScored && !ring.getIsDownScore())
                {
                    dolphin_LevelManager.IncreaseScore(increase);
                    audioSource.Play();
                    isScored = true;
                }

            }
        }
        

    }
}
