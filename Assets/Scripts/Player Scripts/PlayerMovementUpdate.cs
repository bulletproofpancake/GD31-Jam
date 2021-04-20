﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementUpdate : MonoBehaviour
{

    private Animator animator;

    //for flip
    private bool facingRight = true;

    //for move
    public CharacterController controller;
    private Vector3 dir;
    public float speed;

    //for jump 
    public float jumpForce = 300f; 
    public Transform groundCheck;
    public float checkRadius;
    private bool isGrounded;
    public LayerMask whatIsGround;
    private bool isJumping = false;
    public float gravity = -20;

    //for double jump
    bool canDoubleJump = true;



    //for dash
    private int extraDash;
    public int extraDashValue;
    public GameObject dashEffect;
    public float DashForce;
    public float DashTimer;
    bool isDashing;
    Vector3 dash;



    void Start()
    {
   	 animator = GetComponent<Animator>();

        extraDash = extraDashValue;

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, whatIsGround);

        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        dir.x = hInput * speed;

        controller.Move(dir * Time.deltaTime);

        dash = transform.right * hInput + transform.forward * vInput;
        jump();
        

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
            
        }

    }
    IEnumerator Dash()
    {
        if (extraDash >0)
        {
            float startTime = Time.time;
            while (Time.time < startTime + DashTimer)
            {
                isDashing = true;
                //FindObjectOfType<AudioManager>().Play("dash");
                controller.Move(dash * DashForce * Time.deltaTime);
                yield return null;
                --extraDash;
            }
        }
    }
    private void jump()
    {
        if (isGrounded)
        {
            canDoubleJump = true;
            extraDash = 1;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // animator.SetBool("isJumping", true);
                //FindObjectOfType<AudioManagerScript>().Play("Jump_Sound");
                isJumping = true;
                dir.y = jumpForce;
            }

        }
        else
        {
            dir.y += gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
            {
                //FindObjectOfType<AudioManagerScript>().Play("Jump_Sound");
                dir.y = jumpForce;
                canDoubleJump = false;
            }
        }
    }

}
