using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Fish_ButtonManager : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public GameObject bullet;
    public Sprite shoot_on_Image;
    Image image;
    Sprite original_Image;
    AudioSource audioSource;
    Fish_TutorialManager fish_TutorialManager;
    GameObject service;
    LevelManager levelManager;
    bool canFire = true;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        service = GameObject.FindGameObjectWithTag("Service");
        fish_TutorialManager = service.GetComponent<Fish_TutorialManager>();
        levelManager = service.GetComponent<LevelManager>();
        image = GetComponent<Image>();
        original_Image = image.sprite;       
    }
    public void OnPointerDown(PointerEventData eventData)
    {      
        image.sprite = shoot_on_Image;
        audioSource.Play();
        if (canFire && fish_TutorialManager.GetBulletOn())
            StartCoroutine(delay());
    }

    public void OnPointerUp(PointerEventData eventData)
    {       
        image.sprite = original_Image;

    }
    IEnumerator delay()
    {
        canFire = false;
        Instantiate(bullet, levelManager.player.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }
}
