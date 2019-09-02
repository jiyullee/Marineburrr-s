using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownFish : MonoBehaviour
{
    GameObject service;
    private void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Shark")
        {
            service.GetComponent<LevelManager>().score -= 5;
        }
        else if (collider.gameObject.tag == "Food")
        {
            service.GetComponent<LevelManager>().score += 5;
        }
    }
}
