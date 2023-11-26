using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemies : MonoBehaviour
{
    public int maxenemyHealth = 100;
    private int currentHealth;
    [SerializeField] private int damageEnemy;

    public bool roaming = true;
    public float moveSpeed;
    public float nextWPDistance;
    public Seeker seeker;
    public bool updateContinuousPath;
    bool reachDestination = false;
    Path path;

    //Shoot
    public bool isShoottable;
    public GameObject bullet = null;
    public float bulletSpeed;
    public float TimebtwFire;
    private float fireCooldown;

    Coroutine moveCoroutine;
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                if (PermenantUI.perm != null)
                {
                    InvokeRepeating("getHealthy",0.0f,1.0f);
                    InvokeRepeating("ShowDamageText",0.0f,1.0f);

                }
             }   
    }
    private void ShowDamageText()
    {
        healthDisplayUI.Instance.ShowDamageText(-damageEnemy);
    }
    private void OnCollisionExit2D(Collision2D other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        CancelInvoke("getHealthy");
        CancelInvoke("ShowDamageText");
    }
}
    public void getHealthy()
    {
         PermenantUI.perm.currentHealth-=damageEnemy;

    }
    void Die()
    {
        Destroy(gameObject);
        Debug.LogWarning("ENEMY DIED");
    }
    void CaculatePath()
    {
        Vector2 target = FindTarget();
        if (seeker.IsDone() && reachDestination || updateContinuousPath)
        {
            seeker.StartPath(transform.position, target, OnPathCompleted);
        }
    }
    void OnPathCompleted(Path p)
    {
        if (!p.error)
        {
            path = p;
            MoveToTarget();
        }
    }
    void MoveToTarget()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }
    IEnumerator MoveToTargetCoroutine()
    {
        int currentWP = 0;
        reachDestination = false;
        while (currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;
            transform.position += (Vector3)force;

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWPDistance)
                currentWP++;

            yield return null;
        }
        reachDestination = true;
    }
    Vector2 FindTarget()
    {
        Vector3 playePos = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (roaming == true)
        {
            return (Vector2)playePos + Random.Range(5f, 10f) * new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
        }
        else
        {
            return (Vector2)playePos;
        }
    }
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
        reachDestination = true;
        InvokeRepeating("CaculatePath", 0f, 0.5f);
        currentHealth = maxenemyHealth;
    }
    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (fireCooldown < 0 && isShoottable)
        {
            fireCooldown = TimebtwFire;
            //shoot 
            EnemyFireBullet();
        }
    }
}