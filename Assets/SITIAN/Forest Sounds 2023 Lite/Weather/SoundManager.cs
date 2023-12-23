using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource  backgroundSound;

    private void Awake()
    {
        backgroundSound=GetComponent<AudioSource>();
    }
    private void Start()
    {
        if(backgroundSound!=null)
        {
            Debug.LogWarning("BackgroundSound in scene1 is null");
        }
        backgroundSound.Play();
    }
}
