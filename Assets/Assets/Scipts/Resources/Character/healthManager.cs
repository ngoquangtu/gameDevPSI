using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public interface INTERhealthManager
{
    void SetMaxHealth(float max);
    void TakeDamage(float damage);
    void UpdateHealthBar();
}
public class healthManager : MonoBehaviour,INTERhealthManager
{
    public Slider healthBar;
    protected  float maxHealth;
    protected  float currentHealth;

    protected virtual void Start()
    {    }
    private void Update()
    {
        UpdateHealthBar();
        Debug.Log(currentHealth);
        Debug.Log(healthBar.value);
    }
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth=Mathf.Clamp(currentHealth,0,maxHealth);
        Debug.LogWarning(maxHealth);
        UpdateHealthBar();
        if(currentHealth<=0)
        {
            Debug.LogWarning("Player Died");
        }
    }
    public  void SetMaxHealth(float max)
    {
        maxHealth = max;
        currentHealth = max;
        Debug.LogWarning(maxHealth);
        Debug.LogWarning("mau max"+max);
        UpdateHealthBar();
    }
    public void UpdateHealthBar()
    {
        healthBar.value=currentHealth/maxHealth;
        Debug.Log("Maxhealth"+maxHealth);
    }
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
