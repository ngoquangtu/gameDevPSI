using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class healthManager : MonoBehaviour
{
    public Slider healthBar;
    public  float maxHealth;
    public  float currentHealth;
    public static healthManager Instance;
    public bool isDead=false;
    
    private void Awake()
    {
        if(Instance==null)
        {
            Instance=this;
        }
        else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        SetMaxHealth(200f);
        UpdateHealthBar();
    }
    void Update()
    {
        UpdateHealthBar();
    }
    public void SetMaxHealth(float maxHealthValue)
    {
        maxHealth = maxHealthValue;
        Debug.LogWarning("mau max khi set : "+maxHealth);
        currentHealth = maxHealth; 
        UpdateHealthBar();
    }
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth=Mathf.Clamp(currentHealth,0,maxHealth);
        Debug.LogWarning(maxHealth);
        UpdateHealthBar();
        if(currentHealth<=0 || healthBar.value<=0)
        {
            Debug.LogWarning("Player Died");
        }
    }

    public  void UpdateHealthBar()
    {   
        if(healthBar==null) return; 
        Debug.LogWarning("mau max"+maxHealth);
        if(maxHealth>0)
        {
            float sliderValue = currentHealth / maxHealth;
            healthBar.value = sliderValue;
        }
    }
}
