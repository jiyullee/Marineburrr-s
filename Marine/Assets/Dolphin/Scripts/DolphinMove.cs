using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinMove : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public bool isJumping = false;
    public bool isGround;
    public bool twoJump;
    public bool jump;
    public new Rigidbody2D rigidbody2D;
    public Transform ground;
    public float checkRadius;
    [SerializeField]
    LayerMask layer;
    public int mayJumpCount;
    int jumpCnt;
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
       
    }
    private void Start()
    {
        jumpCnt = mayJumpCount;
    }  

}