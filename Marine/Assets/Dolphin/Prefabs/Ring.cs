using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    GameObject service;
    Dolphin_LevelManager dolphin_LevelManager;
    public float speed;
    public float lifeTime;
    bool isReached = false;

    private void Start()
    {      
        dolphin_LevelManager = GameObject.FindGameObjectWithTag("Service").GetComponent<Dolphin_LevelManager>();
    }
    private void OnEnable()
    {        
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
    
    public void ChangeisReach()
    {
        isReached = true;
    }

    public bool GetIsReach()
    {
        return isReached;
    }
   
}
