using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_InputManager : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
   
}
