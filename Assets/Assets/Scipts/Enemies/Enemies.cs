using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int maxenemyHealth = 100;
    private int currentHealth;
    [SerializeField] private float damageEnemy;

    void Start()
    {
        currentHealth = maxenemyHealth;
    }

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
                    InvokeRepeating("getHealthy",0.0f,0.1f);
                    Debug.Log(PermenantUI.perm.currentHealth);
                }
             }   
    }
    public void getHealthy()
    {
            PermenantUI.perm.currentHealth-=damageEnemy;
            if( PermenantUI.perm.currentHealth<=0)
            {
                Debug.LogError(" player da chet");
            }
    }
    void Die()
    {
        Destroy(gameObject);
        Debug.LogWarning("ENEMY DIED");
    }
}
