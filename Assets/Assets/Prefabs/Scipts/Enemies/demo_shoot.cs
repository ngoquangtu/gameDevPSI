using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo_shoot : MonoBehaviour
{
    //Shoot
    public GameObject bullet ;
    public float bulletSpeed;
    public float TimebtwFire;
    private float fireCooldown;

    void EnemyFireBullet()
    {
        var bulletTmp = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        Vector3 playePos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 direction = new Vector3(1,1,0) - (Vector3)transform.position;
        rb.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (fireCooldown < 0)
        {
            fireCooldown = TimebtwFire;
            //shoot 
            EnemyFireBullet();
        }
    }
}
