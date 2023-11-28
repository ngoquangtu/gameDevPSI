using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteMan : Character
{
    public whiteMan(GameObject gameObject):base(gameObject)
    {
        speed=5;
        hp=200;
        damagePlayer=15;
    }
}
