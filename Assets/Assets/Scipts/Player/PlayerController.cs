using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    private Animator anim;
    CapsuleCollider2D capsuleCollider;
    [SerializeField] private float moveSpeed = 5f;

    public float horizontalInput;
    public float verticalInput;
    private Vector2 targetVelocity;
    bool checkGoup;


    private enum State { idle, running, runningup }
    private State state=State.idle;
  
    private void Start() 
    {
          myRigidBody = GetComponent<Rigidbody2D>();
          capsuleCollider = GetComponent<CapsuleCollider2D>();
          anim= GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        MoveCharacter();
    }
    private void Update()
    {
        
        VelocityState();
        anim.SetInteger("state", (int)state);
        myRigidBody.gravityScale = 0f;
    }

    protected void MoveCharacter()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
        targetVelocity = moveDirection.normalized * moveSpeed;
        myRigidBody.velocity = Vector2.Lerp(myRigidBody.velocity, targetVelocity, 0.1f);
        Flip();
    }
    // protected void checkMove()
    // {
    //     if(Mathf.Abs(myRigidBody.velocity.x)>1.0f || Mathf.Abs(myRigidBody.velocity.y)>1.0f)
    //     {
    //         SoundManager.Instance.PlaySound(SoundManager.Instance._moveSound);
    //     }
    // }
    void Flip()
    {
        if (horizontalInput < 0)
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, myRigidBody.velocity.y);
            transform.localScale = new Vector2(-1, 1);

            
        }
        else if (horizontalInput > 0)
        {
            myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
            transform.localScale = new Vector2(1, 1);

        }
        else if (verticalInput<0 && checkGoup)
        {
            myRigidBody.velocity= new Vector2(myRigidBody.velocity.x,-moveSpeed);
            transform.localScale = new Vector2(1, -1);

        }
        else if(verticalInput>0)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, moveSpeed);
            transform.localScale = new Vector2(1, 1);

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("maze"))
        {
            checkGoup = true;
        }
        else
        {
            checkGoup = false;
        }
    }
    protected void VelocityState()
    {
        if (Mathf.Abs(myRigidBody.velocity.x) > 1.0f)
        {
            state = State.running;

        }
        else if (Mathf.Abs(myRigidBody.velocity.y) > 1.0f)
        {
            state = State.runningup;
        }
        else
        {
            state = State.idle;
        }
    }
}
