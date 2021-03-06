﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{

    private Rigidbody2D rb;
    private Animator anim;
    private FixedJoystick joystick;

    public float speed;
    public float jumpForce;

    [Header("Player State")]
    public float health;
    public bool isDead;

    [Header("Gound Check")]
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;


    [Header("States Check")]
    public bool isGround;
    public bool canJump;
    public bool isJump;

    [Header("Jump FX")]
    public GameObject jumpFX;
    public GameObject landFX;

    [Header("Attack Settings")]
    public GameObject bombPrefab;
    public float nextAttack = 0;
    public float attackRate;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        joystick = FindObjectOfType<FixedJoystick>();

        health = GameManager.instance.LoadHealth();
        UIManager.instance.UpdateHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("dead", isDead);
        if (isDead)
        {
            return;
        }

        CheckInput();
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        PhysicsCheck();
        Movement();
        Jump();
    }

    private void Movement()
    {
        // 键盘操作
        //float horizontalInput = Input.GetAxisRaw("Horizontal");

        // 按钮操作
        float horizontalInput = joystick.Horizontal;
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        //if (horizontalInput != 0)
        //{
        //    transform.localScale = new Vector3(horizontalInput, 1, 1);
        //}

        if (horizontalInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (horizontalInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void CheckInput()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            canJump = true;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Attck();
        }
    }

    void Jump()
    {
        if (canJump)
        {
            isJump = true;
            jumpFX.SetActive(true);
            jumpFX.transform.position = transform.position + new Vector3(0, -0.4f, 0);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.gravityScale = 4;
            canJump = false;
        }
    }

    public void ButtonJump()
    {
        canJump = true;
    }

    public void Attck()
    {
        if (Time.time > nextAttack)
        {
            Instantiate(bombPrefab, transform.position, bombPrefab.transform.rotation);

            nextAttack = Time.time + attackRate;
        }
    }

    private void PhysicsCheck()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (isGround)
        {
            rb.gravityScale = 1;
            isJump = false;
        }
    }


    public void LandFX()
    {
        landFX.SetActive(true);
        landFX.transform.position = transform.position + new Vector3(0, -0.7f, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

    public void GetHit(float damage)
    {
        if (!anim.GetCurrentAnimatorStateInfo(1).IsName("player_hit"))
        {
            health -= damage;
            if (health < 1)
            {
                health = 0;
                isDead = true;
            }

            anim.SetTrigger("hit");

            UIManager.instance.UpdateHealth(health);
        }
    }
}
