using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEffect : MonoBehaviour
{
public GameObject hitEffectPrefab;
private bool hasHit = false;
public static bulletEffect instance;
public int damagePlayer = 10;

private void Awake() 
{
    if(instance == null)
    {
        instance=this;
    }
}
private void OnCollisionEnter2D(Collision2D collision)
{
    if (!hasHit && hitEffectPrefab != null)
    {
        GameObject effectBullet=Instantiate(hitEffectPrefab, collision.contacts[0].point, Quaternion.identity);
        hasHit = true; 
        Destroy(effectBullet,0.1f);
        gameObject.SetActive(false);
    } 
            if(collision.collider.CompareTag("Enemy"))
            {
                Enemies enemy=collision.collider.GetComponent<Enemies>();
                if(enemy != null )
                {
                    enemy.TakeDamage(damagePlayer);
                }
            }
        } 
}

