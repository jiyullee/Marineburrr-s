using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_Animation : MonoBehaviour
{
    public Animator anim;
    bool isSlide;
    Ground ground;
    Dolphin dolphin;
    public GameObject slide;  
    CapsuleCollider2D capsuleCollider2D;
    Vector2 offset;
    Vector2 slideOff;
    Vector2 size;
    Vector2 slidesize;
    void Start()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        offset = capsuleCollider2D.offset;
        size = capsuleCollider2D.size;
        slideOff = slide.GetComponent<CapsuleCollider2D>().offset;
        slidesize = slide.GetComponent<CapsuleCollider2D>().size;
        dolphin = GetComponent<Dolphin>();
        ground = GameObject.FindGameObjectWithTag("Ground").GetComponent<Ground>();
        anim = GetComponent<Animator>();
      
    }

    private void Update()
    {
        if (isSlide)
        {
            slide.SetActive(true);
            capsuleCollider2D.size = slidesize;
            capsuleCollider2D.offset = slideOff;
            ground.Fallout();
        }

        else
        {
            slide.SetActive(false);
            capsuleCollider2D.size = size;
            capsuleCollider2D.offset = offset;
            ground.Bulge();
        }

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
