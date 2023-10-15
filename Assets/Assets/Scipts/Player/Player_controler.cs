using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controler : MonoBehaviour
{
    public float moveSpeed = 5.0f;


    private Rigidbody2D rb;
    public float rollBoost = 2.0f;
    private float rolltime;
    public float Rolltime; // truy cập giá trị từ bên unity component
    bool rollOnce = false;

    public Animator animator; // gọi class 
    public SpriteRenderer CharacterSR;

    public Vector3 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>(); // câu lệnh gọi animator
    }

    // Update is called once per frame
    void Update()
    {

        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        animator.SetFloat("Speed", moveInput.sqrMagnitude); //sqrManitude là lấy độ dài vector

        if (moveInput.x != 0)
        {
            if (moveInput.x > 0)
                CharacterSR.transform.localScale = new Vector3(1, 1, 0);
            else if (moveInput.x < 0)
                CharacterSR.transform.localScale = new Vector3(-1, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && rolltime <= 0)
        {
            animator.SetBool("Roll", true);
            moveSpeed *= rollBoost;
            rolltime = Rolltime;
            rollOnce = true;

        }
        if (rolltime <= 0 && rollOnce == true)
        {
            animator.SetBool("Roll", false);
            moveSpeed /= rollBoost;
            rollOnce = false;
        }
        else
        {
            rolltime -= Time.deltaTime;
        }
    }
}
