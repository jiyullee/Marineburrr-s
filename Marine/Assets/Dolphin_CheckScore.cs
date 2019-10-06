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
    public AudioClip increaseAudio;
    public AudioClip decreaseAudio;
    AudioSource audioSource;
    SpriteRenderer spriteRenderer;
    Dolphin dolphin;
    private void Start()
    {
        dolphin = GetComponentInParent<Dolphin>();
        spriteRenderer = dolphin.GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
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
                        audioSource.clip = increaseAudio;
                        audioSource.Play();
                        
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
                    audioSource.clip = decreaseAudio;
                    audioSource.Play();
        
                    dolphin_LevelManager.DecreaseScore(decrease);
                    StartCoroutine(ChangeColor());
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
                audioSource.clip = decreaseAudio;
                audioSource.Play();
                StartCoroutine(ChangeColor());
            }
            isCrash = true;
        }
    }
    public bool getIsCrash()
    {
        return isCrash;
    }

    IEnumerator ChangeColor()
    {
        spriteRenderer.color = new Color(190,0,0,255);
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = new Color(255, 255, 255, 255);
    }
}
