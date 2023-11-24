using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ControllerPlayer : MonoBehaviour
{
        public static ControllerPlayer Instance { get; private set; }
        [SerializeField] private  float moveSpeed;
        [SerializeField] private int damagePlayer;
        public float horizontalInput;
        public float verticalInput;
        private Vector2 targetVelocity;
        [SerializeField] private Animator anim;
        private Rigidbody2D rb;
        [SerializeField] private SpriteRenderer characterRenderer;
        
        private enum State{idleside,idleup,idledown,walkside,walkup,walkdown,runside,runup,rundown,died}
        private State state=State.idleside;


        [SerializeField] private UIventory uiventory;
        private bool isSwordActive = false;

        private void Awake()
        {
            Instance = this;
            // inventory=new Inventory();
            // uiventory.SetInventory(inventory);
        }
        private void Start()
        {
            rb=GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate() 
        {
            VelocityState();
            ApplyState();
        }
        private void Update()
        {

            Moving();
            checkDied();
        }

        private void Moving()
        {     
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
            rb.velocity = moveDirection.normalized * moveSpeed; 
            Flip();
        }
        void Flip()
        {
            if (horizontalInput < 0)
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                characterRenderer.transform.localScale = new Vector2(1, 1);
            }
            else if (horizontalInput > 0)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                characterRenderer.transform.localScale = new Vector2(-1, 1);

            }
        }
        protected void VelocityState()
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
            else if(PermenantUI.perm.currentHealth<=0)
            {
                state=State.died;
            }
        
        }
        private void checkDied()
        {
            if(state==State.died)
            {
                Debug.Log("REGAME");

            }
        }
        protected void ApplyState()
        {
            anim.SetInteger("state",(int)state);
        }
        public int DamagePlayer
        {
            get 
            { return damagePlayer; }
        }
    } 


