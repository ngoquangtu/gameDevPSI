using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPotion : MonoBehaviour
{
    [SerializeField] private int healthBonus=10;
    private void OnCollisionEnter2D(Collision2D other)
    {
         if(other.gameObject.CompareTag("healthPotion"))
         {
            PermenantUI.perm.currentHealth+=healthBonus;
            Destroy(other.gameObject);
            ShowBonusHealth();
         }
    }
    private void ShowBonusHealth()
    {
        healthDisplayUI.Instance.ShowBonusHealthText(healthBonus);
    }
}
