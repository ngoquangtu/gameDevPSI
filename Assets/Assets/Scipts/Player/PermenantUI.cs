using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class PermenantUI : MonoBehaviour
{
     public Slider healthBar;
    public float maxHealth = 100f;
    public float currentHealth;
    public static PermenantUI perm;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        if(!perm)
        {
            perm=this;
        }
        currentHealth = maxHealth;
    }
    private void Update()
    {
        UpdateHealthBar();
    }
    public void healthSlider()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth); 
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.value = currentHealth / maxHealth;
    }
}
