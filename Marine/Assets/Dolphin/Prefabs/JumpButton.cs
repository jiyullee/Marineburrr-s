using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class JumpButton : MonoBehaviour,IPointerUpHandler, IPointerDownHandler
{
    bool jump;
    Dolphin_Jump dolphin_Jump;
    public GameObject service;
    AudioSource audioSource;
    Dolphin_LevelManager dolphin_LevelManager;
    GameObject player;
    private void Start()
    {        
        dolphin_LevelManager = service.GetComponent<Dolphin_LevelManager>();
        player = dolphin_LevelManager.player;
        dolphin_Jump = player.GetComponent<Dolphin_Jump>();
        audioSource = GetComponent<AudioSource>();
    }
      
    public void OnPointerDown(PointerEventData eventData)
    {        
        dolphin_Jump.CheckJump();
        dolphin_Jump.CheckTwoJump();        
        audioSource.Play();
    }

    public void OnPointerUp(PointerEventData eventData)
    {     
        dolphin_Jump.DecreaseJumpCount();
    }    
    
}
