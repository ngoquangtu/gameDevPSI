using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int maxenemyHealth = 100;
    private int currentHealth;
    [SerializeField] private int damageEnemy;

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
}