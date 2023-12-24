using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPotion : MonoBehaviour
{
    [SerializeField] private float bonusHealth;
    

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            healthManager.Instance.currentHealth+=bonusHealth;
            healthDisplayUI.Instance.ShowBonusHealthText(bonusHealth);
            Destroy(gameObject);
        }    
    }
}
