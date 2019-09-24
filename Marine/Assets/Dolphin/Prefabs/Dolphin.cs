using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin : MonoBehaviour
{
    GameObject service;

    private void Awake()
    {
        service = GameObject.FindGameObjectWithTag("Service");
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Food")
        {
            service.GetComponent<Dolphin_LevelManager>().score += collider.GetComponent<Feed>().increase;
            Destroy(collider.gameObject);
        }

    }


}
