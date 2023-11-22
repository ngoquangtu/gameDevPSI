using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance{get;private set;}

    private void Awake()
    {
    if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject);
    }
    public Sprite swordSprite;
    public Sprite healthPotionSprite;
    public Sprite coinSprite;
    public Sprite manaSprite;
    public Sprite bombSprite;



}
