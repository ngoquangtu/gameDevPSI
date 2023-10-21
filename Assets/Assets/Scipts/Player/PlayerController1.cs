using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
 [Header("Movement Params")]
    [SerializeField] private float runSpeed = 6.0f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravityScale = 20.0f;

    Vector2 moveDirection = Vector2.zero;
    bool jumpPressed=false;

    [Header("Particles system")]
    [SerializeField] private ParticleSystem deathPlayerParticles;

    [Header("Components player")]
    
    private BoxCollider2D coll;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    [Header("other")]

    private bool isFacingRight=true;
    private bool isGrounded=false;
    private bool disableMovement=false;

    private void Awake()
    {
        coll=GetComponent<BoxCollider2D>();
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        sr=GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate() 
    {
        if(disableMovement)
        {
            return;
        }    
        HandleInput();
        MoveMent();
        UpdateFlip();
    }
    private void HandleInput()
    {
        moveDirection= InputManager1.instance.GetMoveDirection();
        jumpPressed= InputManager1.instance.GetJumpPressed();
    }
    private void MoveMent()
    {
        rb.velocity=new Vector2(moveDirection.x*runSpeed, rb.velocity.y);

    }
    private void Jumping()
    {
        if(isGrounded && jumpPressed)
        {
            isGrounded=false;
            rb.velocity=new Vector3(rb.velocity.x,jumpSpeed);
        }
    }

    private void UpdateFlip()
    {
        if(moveDirection.x>0.1f)
        {
            isFacingRight=true;
        }
        else if(moveDirection.x<-0.1f)
        {
            isFacingRight=false;
        }
        if (isFacingRight)
        {
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 0, this.transform.eulerAngles.z);
        }
        else if(!isFacingRight)
        {
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 180, this.transform.eulerAngles.z);
        }
    }
}
