using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SlideButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject service;
    GameObject player;
    Dolphin_Input dolphin_Input;
    AudioSource audioSource;
    Dolphin_LevelManager dolphin_LevelManager;
    private void Start()
    {     
        audioSource = GetComponent<AudioSource>();       
        dolphin_LevelManager = service.GetComponent<Dolphin_LevelManager>();
        player = dolphin_LevelManager.player;
        dolphin_Input = player.GetComponent<Dolphin_Input>();
    }
 
    public void OnPointerDown(PointerEventData eventData)
    {
        dolphin_Input.Slide();
        audioSource.Play();
    }

    public void OnPointerUp(PointerEventData eventData)
    {       
        dolphin_Input.StandUp();      
    }
       
}

