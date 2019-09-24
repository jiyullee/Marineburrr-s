using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_Action : MonoBehaviour
{
    public Animator anim;
    Rigidbody2D rd;
    bool isFalling;
    void Start()
    {
        anim = GetComponent<Animator>();
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rd.velocity.y < 0)
            anim.SetBool("Jump", false);
       
            
        if (GetComponent<DolphinMove>().jump)
        {
            anim.SetBool("Jump", true);
            
        }
        if (GetComponent<DolphinMove>().twoJump)
        {
            //anim.SetBool("Jump", true);
            anim.SetTrigger("TwoJump");
        }

        if (Input.GetKeyDown(KeyCode.D))
            anim.SetTrigger("Slide");
        if (Input.GetKeyUp(KeyCode.D))
            anim.SetTrigger("StandUp");
    }
}
