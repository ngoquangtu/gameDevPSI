using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    [SerializeField] private Transform posBullet;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject gunObject;
    [SerializeField] private GameObject bulletEffect;
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
     [SerializeField] private float bulletSpread=10f;
     [SerializeField] private float recoilForce=2.0f;

    private AudioSource audioShot;

    private CrossHairManager crossHairManager;
    private void Awake()
    {
        audioShot = GetComponent<AudioSource>();
        gunAnim=GetComponent<Animator>();
    }
    private void Start()
    {
        crossHairManager = new CrossHairManager();
        crossHairManager.UpdateCrosshair();
        hideCusor();

    }
    void Update()
    {
        rotateGun();
        crossHairManager.UpdateCrosshair();
        timeBtwFire -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timeBtwFire <0) 
        { 
            bulletEffect.SetActive(true);
            Shoot();
        }
        else
        {
            bulletEffect.SetActive(false);
        }
    }

    void rotateGun()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        randomAngleBullet=Random.Range(-bulletSpread,bulletSpread);
        angleBullet=angle+randomAngleBullet;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angleBullet);
        gunObject.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        if(transform.eulerAngles.z>90 && transform.eulerAngles.z<270)
        {
            transform.localScale=new Vector3(-1,-1,0);
        }
        else
        {
            transform.localScale=new Vector3(-1,1,0);
        }
    }
    void Shoot()
    {
        timeBtwFire=TimeBtwFire;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bulletDirection = (mousePosition - posBullet.position).normalized;
        Quaternion bulletRotation = Quaternion.Euler(0f, 0f, angleBullet);
        bullet = Instantiate(bulletPrefab, posBullet.position, bulletRotation); 
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        CinemacineShake.instance.ShakeCamera(5f,0.1f);
        // rb.AddForce(transform.right*bulletSpeed, ForceMode2D.Impulse);
        rb.velocity = transform.right * bulletSpeed;
        gunAnim.SetTrigger("Shoot");
        audioShot.Play();
        Destroy(bullet, 5f);
    }
    void hideCusor()
    {
        Cursor.visible = false; 
    }
}
