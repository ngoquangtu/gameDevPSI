using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UI;
using UnityEngine.Events;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemies : MonoBehaviour
{
    public int maxenemyHealth = 100;
    private int currentHealth;
    [SerializeField] private int damage = 0;

    public UnityEvent OnDeath;

    //Ui
    public HealthBar healthBar;

    public bool ismovetable;
    public float moveSpeed;
    public float nextWPDistance;
    public Seeker seeker;
    public bool updateContinuousPath;
    private bool reachDestination = false;
    private bool roaming =false ; // update path occasionally
    Path path;
    Coroutine moveCoroutine;    

    public void TakeDamage()
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            OnDeath.Invoke();
        }
    }
    private void OnEnable()
    {
        OnDeath.AddListener(Die);
    }
    private void OnDisable()
    {
        OnDeath.RemoveListener(Die);
    }
    private void OnCollisionEnter2D(Collision2D other)
        {
        if (other.gameObject.CompareTag("Player"))
            {
            damage = 10;  
            InvokeRepeating("TakeDamage", 0.0f, 0.1f);
             }   
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CancelInvoke("TakeDamage");
        }
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
            if (direction.x < 0)
            {
                if (transform.GetChild(0).transform.localScale.x > 0)
                    transform.GetChild(0).transform.localScale *= new Vector2(-1, 1);
            }
            else
            {
                if (transform.GetChild(0).transform.localScale.x < 0)
                    transform.GetChild(0).transform.localScale *= new Vector2(-1, 1);
            }
        }
        reachDestination = true;
    }
    Vector2 FindTarget()
    {
        Vector3 playePos = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (roaming == true)
        {
            return (Vector2)playePos + Random.Range(6f, 10f) * new Vector2(Random.Range(-10, 10), Random.Range(-10, 10)).normalized;
        }
        else
        {
            return (Vector2)playePos;
        }
    }
    public bool set_reachDestination(bool c)
    {
        reachDestination=c;
        return reachDestination;
    }
    public bool set_roaming(bool c)
    {
        roaming = c;
        return roaming;
    }
    public void set_currentHealth(int currenthealth)
    {
        currentHealth = currenthealth;
    }
    public int get_currentHealth() 
    {
        return currentHealth;
    }
    public void run()
    {
        set_reachDestination(true);
        InvokeRepeating("CaculatePath", 0f, 0.5f);
    }
    void Start()
    {
        if (ismovetable)
            run();
        currentHealth = maxenemyHealth;
    }
    void Update()
    {
        healthBar.UpdateHealth(currentHealth, maxenemyHealth);
    }
}