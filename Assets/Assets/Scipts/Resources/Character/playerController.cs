using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Character player;
    void Start()
    {
        player=InitPlayer.player;
    }
    void Update()
    {
        player.Update();
    }
}
