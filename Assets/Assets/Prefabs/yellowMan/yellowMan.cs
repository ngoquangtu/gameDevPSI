using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowMan : MonoBehaviour
{
        public static yellowMan Instance;
        
        [SerializeField] private  float moveSpeed;
        [SerializeField] private float damagePlayer;
        public float horizontalInput;
        public float verticalInput;
        [SerializeField] private Animator anim;
        private Rigidbody2D rb;
        [SerializeField] private SpriteRenderer characterRenderer;  
        private enum State{idleside,idleup,idledown,walkside,walkup,walkdown,runside,runup,rundown,died}
        private State state=State.idleside;
        

        [SerializeField] private UIventory uiventory;

        private void Awake()
        {
            if(Instance==null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

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
            if(!healthManager.Instance.isDead)
            {
            Moving();
            }
            isDead();
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
            else if(healthManager.Instance.currentHealth<=0)
            {
                state=State.died;
            }
        
        }
        private void isDead()
        {
            if(state==State.died)
            {
               healthManager.Instance.isDead=true;
            }
        }
        protected void ApplyState()
        {
            anim.SetInteger("state",(int)state);
        }
        public float DamagePlayer
        {
            get 
            { return damagePlayer; }
        }
    } 