using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Weapon_enemies : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;

    public float TimeBtwFire;
    public float bulletForce;

    private float timeBtwFire;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();
        timeBtwFire -= Time.deltaTime;
        FireBullet();
       
    }
    void RotateGun()
    {
        Vector3 playerPos = FindObjectOfType<ControllerPlayer>().transform.position;
        Vector3 mousePo = Camera.main.ScreenToWorldPoint(Input.mousePosition); // trả về giá trị của  con trỏ chuyện só trong khung hình(camera)
        Vector2 lookdir = playerPos - Camera.main.transform.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        { transform.localScale = new Vector3(1, -1, 0); }
        else
        { transform.localScale = new Vector3(1, 1, 0); }
    }

    void FireBullet()
    {
        timeBtwFire = TimeBtwFire;

        // khởi tạo một vật ở vị trí với góc
        GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);


        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        //thêm lực vào vật
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);


    }
}
