using UnityEngine;
using UnityEngine.UI;


public class playerHealth : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 100f; // Giá trị máu tối đa
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamagePlayer(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth); 
        UpdateHealthBar();
        if(currentHealth<=0)
        {
            Debug.LogWarning("Player Died");
        }
    }

    void UpdateHealthBar()
    {
        healthBar.value = currentHealth / maxHealth;
    }
}
