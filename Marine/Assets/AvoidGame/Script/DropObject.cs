﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class DropObject : MonoBehaviour
{
    public GameObject service;
    int level = 1;
    public bool canCrash = true;
    private void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
    }
    private void Update()
    {
        int score = service.GetComponent<AvoidGameManager>().score;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Trash" || collision.gameObject.tag == "Ground")
        {
            if(gameObject.tag == "Trash")
            canCrash = false;
        }
      
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ground")
        {
            Destroy(gameObject);
        }
        else if (collider.tag == "Player" && canCrash == true)
        {
            Function();
            Destroy(gameObject);
        }
    }
   
    abstract public void Function();
}
