using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPotion : MonoBehaviour
{
    [SerializeField] private float healthBonus=10.0f;
    private void OnCollisionEnter2D(Collision2D other)
    {
         if(other.gameObject.CompareTag("healthPotion"))
         {
            PermenantUI.perm.currentHealth+=healthBonus;
            Destroy(other.gameObject);
         }
    }
}
