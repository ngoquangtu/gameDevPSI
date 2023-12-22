using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_enemies : Enemies
{
    //Shoot
    public GameObject bullet = null;
    public float bulletSpeed;
    public float TimebtwFire;
    private float fireCooldown;

    // Start is called before the first frame update
    void EnemyFireBullet()
    {
        var bulletTmp = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        Vector3 playePos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 direction = playePos - (Vector3)transform.position;
        rb.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
    }
    void Start()
    {
        set_roaming(true);
        run();
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
