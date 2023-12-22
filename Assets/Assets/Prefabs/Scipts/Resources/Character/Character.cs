using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected float hp { get; set; }
    protected float speed { get; set; }
    protected float damagePlayer { get; set; }
    protected Rigidbody2D rb { get; set; }
    protected CapsuleCollider2D capsuleCollider2D { get; set; }

    protected float horizontalInput;
    protected float verticalInput;


    public Character(GameObject gameObject)
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        capsuleCollider2D = gameObject.GetComponent<CapsuleCollider2D>();
    }
    protected abstract void Awake();
    public abstract void Update();
    protected abstract  void Moving();
    protected abstract void Flip();
    protected abstract void isDead();
    protected abstract void VelocityState();
    protected abstract void ApplyState();
}
