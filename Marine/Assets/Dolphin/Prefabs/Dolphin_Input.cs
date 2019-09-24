using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_Input : MonoBehaviour
{
    public bool key_A_down;
    public bool key_A_up;
    public bool key_D_down;
    public bool key_D_up;
    Dolphin_Jump dolphin_Jump;
    Dolphin_Animation dolphin_Animation;
    GameObject player;    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dolphin_Jump = GetComponent<Dolphin_Jump>();
        dolphin_Animation = GetComponent<Dolphin_Animation>();
    }
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.D))
        {
            dolphin_Animation.Slide();
            
        }          
        if (Input.GetKeyUp(KeyCode.D))
        {
            dolphin_Animation.StandUp();
           
        }
            


    }
}
