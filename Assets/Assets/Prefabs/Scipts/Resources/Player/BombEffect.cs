using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    private Animator bombAnim;
    private bool hasExploded = false;

    private AudioSource bombAudio;
    [SerializeField] private float timeBoom=5.0f;
    
    private void Awake()
    {
        bombAnim=GetComponent<Animator>();
        bombAudio=GetComponent<AudioSource>();
    }
    private void Update()
    {
        Invoke("ActivateBomb",timeBoom);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasExploded)
        {
            if (bombAnim != null && !collision.gameObject.CompareTag("Player"))
            {
                bombAnim.SetTrigger("Bomb");
                bombAudio.Play();
                Destroy(gameObject,0.3f);
            }
            hasExploded = true;
        }
    }
    private void ActivateBomb()
    {
        if (!hasExploded)
        {
            if (bombAnim != null)
            {
                bombAnim.SetTrigger("Bomb");
                bombAudio.Play();
                Destroy(gameObject, 0.3f);
            }
            hasExploded = true;
        }
    }

}
