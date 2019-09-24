using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_Animation : MonoBehaviour
{
    public Animator anim;
    bool isSlide;
    Ground ground;
    void Start()
    {
        ground = GameObject.FindGameObjectWithTag("Ground").GetComponent<Ground>();
        anim = GetComponent<Animator>();
      
    }

    private void Update()
    {
        if (isSlide)
            ground.Fallout();
        else
            ground.Bulge();

    }
    public void Jump()
    {
        anim.SetTrigger("Jump");
    }
    public void TwoJump()
    {
       anim.SetTrigger("TwoJump");
       
    }
    public void Slide()
    {
        isSlide = true;
        anim.SetTrigger("Slide");
    }
    public void StandUp()
    {
        isSlide = false;
       anim.SetTrigger("StandUp");
    }
}
