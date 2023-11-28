using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    private Animator bombAnim;
    private bool hasExploded = false;
    private AudioSource bombAudio;
    
    private void Awake()
    {
        bombAnim=GetComponent<Animator>();
        bombAudio=GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasExploded)
        {
            if (bombAnim != null)
            {
                bombAnim.SetTrigger("Bomb");
                bombAudio.Play();
                Destroy(gameObject,0.3f);
            }
            hasExploded = true;
        }
    }
}
