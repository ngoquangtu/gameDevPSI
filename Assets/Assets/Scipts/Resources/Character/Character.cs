using System;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;


public  class Character:MonoBehaviour
{
    protected float hp{get;set;}
    protected float speed{get;set;}
    protected float damagePlayer{get;set;}
    protected SpriteRenderer characterRenderer{get;set;}
    protected Rigidbody2D rb{get;set;}
    protected Animator animator{get;set;}
    protected CapsuleCollider2D capsuleCollider2D{get;set;}

    protected float horizontalInput;
    protected float verticalInput;


    protected enum State{idleside,idleup,idledown,walkside,walkup,walkdown,runside,runup,rundown,died}
    protected State state=State.idleside;
    public Character(GameObject gameObject)
    {
        rb=gameObject.GetComponent<Rigidbody2D>();
        animator=gameObject.GetComponent<Animator>();
        capsuleCollider2D=gameObject.GetComponent<CapsuleCollider2D>();
        characterRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (characterRenderer == null)
        {
        characterRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
    }
    protected virtual void Start()
    {
    }
    internal void Update()
    {
        Moving();
        Flip();
        checkDied();
        VelocityState();
        ApplyState();
    }

    private void Moving()
    {     
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            if(rb!=null)
            {
            Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
            rb.velocity = moveDirection.normalized * speed; 
            }
    }
    protected  void Flip()
    {
        if(rb!=null && characterRenderer!=null)
        {
            if (horizontalInput < 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                characterRenderer.transform.localScale = new Vector2(1, 1);
            }
            else if (horizontalInput > 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                characterRenderer.transform.localScale = new Vector2(-1, 1);
            }
        }
    } 
    private void checkDied()
    {
            if(state==State.died)
            {
                Debug.Log("REGAME");
            }
    } 
    protected void VelocityState()
    {
        if(rb!=null)
        {
            if(Mathf.Abs(rb.velocity.x)>3.0f)
            {
                state=State.runside;
            }
            else if(rb.velocity.y>1.0f)
            {
                state=State.runup;
            }
            else if(rb.velocity.y<-1.0f)
            {
                state=State.rundown;
            }
            else if (state==State.runside && Mathf.Abs(rb.velocity.x)<0.1)
            {
                state=State.idleside;
            }
            else if (state==State.runup && Mathf.Abs(rb.velocity.y)<0.1)
            {
                state=State.idleup;
            }
            else if (state==State.rundown && Mathf.Abs(rb.velocity.y)<0.1)
            {
                state=State.idledown;
            } 
            // else if(PermenantUI.perm.currentHealth<=0)
            // {
            //     state=State.died;
            // }d
        }
    }
    protected void ApplyState()
    {
        if(animator!=null)
        {
        animator.SetInteger("state",(int)state);
        }
    }
}
