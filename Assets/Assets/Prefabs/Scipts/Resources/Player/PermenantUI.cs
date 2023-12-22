using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class PermenantUI : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    
    public Slider healthBar;
    public static PermenantUI perm;
    private void Start()
    {
        if (perm == null)
        {
            perm = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
