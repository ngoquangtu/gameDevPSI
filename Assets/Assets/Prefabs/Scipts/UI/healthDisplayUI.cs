using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class healthDisplayUI : MonoBehaviour
{
    public TMP_Text damageTextPrefab; 
    public TMP_Text healthPotionTextPrefab;
    public Transform canvasTransform; 
    public float damageDuration = 1.0f;
    public float damageSpeed = 1.0f; 

    public static healthDisplayUI Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance=this;
            
        }
    }
    public void ShowDamageText(float damage)
    {
        TMP_Text damageText = Instantiate(damageTextPrefab, canvasTransform);
        
        damageText.text = damage.ToString();
        

        StartCoroutine(MoveAndDestroy(damageText));
    }
    public void ShowBonusHealthText(float healthBonus)
    {
        TMP_Text healthPotionText = Instantiate(healthPotionTextPrefab, canvasTransform);
        healthPotionText.text=healthBonus.ToString();
        StartCoroutine(MoveAndDestroy(healthPotionText));
    }
    IEnumerator MoveAndDestroy(TMP_Text damageText)
    {
        float elapsedTime = 0f;
        Vector3 startPosition = damageText.transform.position;
         Color startColor = damageText.color;

        while (elapsedTime < damageDuration)
        {
            damageText.transform.position = Vector3.Lerp(startPosition, startPosition + Vector3.up, elapsedTime / damageSpeed);
            float alpha = Mathf.Lerp(startColor.a, 0f, elapsedTime / damageDuration);
            damageText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
            Destroy(damageText.gameObject);
    }
}
