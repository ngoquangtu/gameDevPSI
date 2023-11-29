using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Ui


public class HealthBar : MonoBehaviour
{
    
    public Image fillbar;
    public void UpdateHealth(int currentValue, int maxValue)
    {
        Debug.Log("a");
        fillbar.fillAmount = (float)currentValue / (float)maxValue;
    }
}
