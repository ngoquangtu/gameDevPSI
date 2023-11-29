using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class redMan : Character,INTERhealthManager
{
    private healthManager healthmanage;
    private float currentHealth;
    public redMan(GameObject gameObject):base(gameObject)
    {
        speed = 10;
        hp = 200;
        damagePlayer = 15;
        Debug.LogWarning("da duoc goi"+hp);
    }
    protected override void Start()
    {
        base.Start();
        healthmanage = FindObjectOfType<healthManager>();
        if (healthmanage != null)
        {
            healthmanage.SetMaxHealth(hp);
            Debug.LogWarning("hp"+hp);
        }
    }
    private void Update()
    {
        healthmanage.UpdateHealthBar();
        // healthmanage.TakeDamage(damagePlayer);
        currentHealth = healthmanage.GetCurrentHealth();
        Debug.Log("Mau hien tai:"+currentHealth);
    }
    public void SetMaxHealth(float max)
    {
        if (healthmanage != null)
        {
            healthmanage.SetMaxHealth(max);
        }
        else
        {
            Debug.LogError("healthManagerReference is null");
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (healthmanage != null)
        {
            healthmanage.TakeDamage(damageAmount);
            
        }
        else
        {
            Debug.LogError("healthManagerReference is null");
        }
    }
     public void UpdateHealthBar()
    {
        if (healthmanage != null)
        {
            healthmanage.UpdateHealthBar();
        }
        else
        {
            Debug.LogError("healthManagerReference is null.");
        }
    }

}

