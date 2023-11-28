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
    internal  float maxHealth;
    internal  float currentHealth;

    public void Update()
    {
        UpdateHealthBar();
        Debug.Log(currentHealth);
    }
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage*Time.deltaTime;
        currentHealth=Mathf.Clamp(currentHealth,-1,maxHealth);
        UpdateHealthBar();
        if(currentHealth<=0)
        {
            Debug.LogWarning("Player Died");
        }
    }
    public void SetMaxHealth(float max)
    {
        maxHealth = max;
        currentHealth = max;
        UpdateHealthBar();
    }
    public void UpdateHealthBar()
    {
        if(maxHealth>0)
        {
            healthBar.value=currentHealth/maxHealth;
        }
    }
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
