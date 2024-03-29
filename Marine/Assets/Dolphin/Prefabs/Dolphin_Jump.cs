﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_Jump : MonoBehaviour
{
    public float jumpPower;
    public bool isGround;
    public bool twoJump;
    public bool jump;
    public Transform ground;
    public float checkRadius;
    [SerializeField]
    LayerMask layer;
    int maxJumpCount = 2;
    static int jumpCount;
    public new Rigidbody2D rigidbody2D;
    Dolphin_Input dolphin_Input;
    Dolphin_Animation dolphin_Animation;
    JumpButton jumpButton;
    void Awake()
    {
        jumpButton = GameObject.FindGameObjectWithTag("JumpButton").GetComponent<JumpButton>();
        dolphin_Animation = GetComponent<Dolphin_Animation>();
        dolphin_Input = GetComponent<Dolphin_Input>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        jumpCount = maxJumpCount;
    }

    void Update()
    {
        isGround = Physics2D.OverlapCircle(ground.position, checkRadius, layer);
        if (isGround && Input.GetKeyDown(KeyCode.A) && jumpCount > 0)
        {
            jumpPower = 1000;
            dolphin_Animation.Jump();
            rigidbody2D.velocity = Vector2.up * jumpPower;
            //   rb.AddForce(Vector2.up * jumpPower ,ForceMode2D.Impulse);
        }
        else if (!isGround && Input.GetKeyDown(KeyCode.A) && jumpCount > 0)
        {
            jumpPower = 900;
            dolphin_Animation.TwoJump();
            rigidbody2D.velocity = Vector2.up * jumpPower;
            //   rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            jumpCount--;

        }
        if (isGround)
        {
            jumpCount = maxJumpCount;        
            dolphin_Animation.anim.SetBool("isFalling",true);
        }
        else
        {
            dolphin_Animation.anim.SetBool("isFalling", false);
        }
     
    }

    public void DecreaseJumpCount()
    {
        jumpCount--;
    }
    public void CheckJump()
    {
        if (isGround && jumpCount > 0)
        {
            jumpPower = 1000;
            rigidbody2D.velocity = Vector2.up * jumpPower;
            dolphin_Animation.Jump();          
        }
    }
    public void CheckTwoJump()
    {
        if (!isGround && jumpCount > 0)
        {
            jumpPower = 900;
            rigidbody2D.velocity = Vector2.up * jumpPower;
            dolphin_Animation.TwoJump();
        }
    }
}
