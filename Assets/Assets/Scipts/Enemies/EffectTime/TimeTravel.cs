using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TimeTravel : MonoBehaviour
{
    [SerializeField] GameObject present ,past;
    [SerializeField] bool presentVisible=true;
    [SerializeField]  private float TimeEffect;
    [SerializeField] private float effectPerSecond;
    [SerializeField] Volume effectVolume;
    [SerializeField] private float transitionTime;


    void Start()
    {

        present.SetActive(presentVisible);
        past.SetActive(!presentVisible);
        effectVolume.weight=0.0f;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&& Time.time>=TimeEffect)
        {
            TimeEffect=Time.time+1/effectPerSecond;
            present.SetActive(!present.activeSelf);
            past.SetActive(!past.activeSelf);
            effectVolume.weight=1.0f;
            Invoke("TurnOffEffect",transitionTime);
        }
    }
    void TurnOffEffect()
    {
        effectVolume.weight=0.0f;
    }
}
