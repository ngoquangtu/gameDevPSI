using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    [SerializeField] private Transform posBullet;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject gunObject;

    private GameObject bullet;
    private Vector3 crosshairPosition;
    private Animator gunAnim;
    private Vector3 mousePosition;

    public float bulletSpeed = 10f;
    public float rotationSpeed = 5f;

    [SerializeField] private float TimeBtwFire=0.2f;
     private float timeBtwFire;
     private float randomAngleBullet;
     private float angleBullet;
    
    // [SerializeField] private GameObject bulletEffect;

    [SerializeField] private float bulletSpread=10f;
     [SerializeField] private float recoilForce=2.0f;

    [SerializeField] private  float smoothSpeed = 100f;

    private AudioSource audioShot;

    private void Awake()
    {
        audioShot = GetComponent<AudioSource>();
        gunAnim=GetComponent<Animator>();
    }
        void Update()
    {
        timeBtwFire -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timeBtwFire <0) 
        { 
            // bulletEffect.SetActive(true);
            Shoot();
        }
        // else
        // {
        //     bulletEffect.SetActive(false);
        // }
    }

    void Shoot()
    {
        timeBtwFire=TimeBtwFire;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bulletDirection = (mousePosition - posBullet.position).normalized;
        Quaternion bulletRotation = Quaternion.Euler(0f, 0f, angleBullet);
        bullet = Instantiate(bulletPrefab, posBullet.position, bulletRotation); 
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right*bulletSpeed, ForceMode2D.Impulse);
        gunAnim.SetTrigger("Shoot");
        audioShot.Play();
        Destroy(bullet, 5f);
    }
}
