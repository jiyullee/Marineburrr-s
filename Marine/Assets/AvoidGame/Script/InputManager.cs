﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject player;
    Vector3 startPos = Vector3.zero;
    Vector3 endPos = Vector3.zero;
     bool right = false;
     bool left = false;

   

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (left == true)
        {
            player.transform.Translate(Vector3.left * player.GetComponent<PlayerMove>().speed);
            player.GetComponent<Animator>().SetBool("Left", true);
            player.GetComponent<Animator>().SetBool("Right", false);
        }
        else if (right == true)
        {
            player.transform.Translate(Vector3.right * player.GetComponent<PlayerMove>().speed);
            player.GetComponent<Animator>().SetBool("Right", true);
            player.GetComponent<Animator>().SetBool("Left", false);
        }
        else
        {
            player.GetComponent<Animator>().SetBool("Right", false);
            player.GetComponent<Animator>().SetBool("Left", false);
        }
        
        
        //mobile
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    Vector3 touchPos = touch.position;
        //    Vector3 diffpos;
        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        startPos = touchPos;
        //    }
        //    if (touch.phase == TouchPhase.Moved)
        //    {
        //        float delection = touchPos.x - startPos.x;
        //        diffpos = new Vector3(touchPos.x - startPos.x, 0.0f, 0.0f);
        //        if(delection < 0)
        //        {
        //            player.GetComponent<Animator>().SetBool("Left", true);
        //            player.GetComponent<Animator>().SetBool("Right", false);
        //        }
        //        else if (delection > 0)
        //        {
        //            player.GetComponent<Animator>().SetBool("Left", false);
        //            player.GetComponent<Animator>().SetBool("Right", true);
        //        }
        //        startPos = touchPos;
        //        player.transform.position += diffpos / 100;
        //    }
        //}
    }
    public void moveRight()
    {
        right = true;
    }
    public void moveLeft()
    {
        left = true;
    }
    public void IdleRight()
    {
        
        right = false;
    }
    public void IdleLeft()
    {
        left = false;
    }
}
