﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_DolphinMove : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}
