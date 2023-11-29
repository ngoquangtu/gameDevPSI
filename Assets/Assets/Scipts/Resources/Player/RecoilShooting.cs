using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilShooting : MonoBehaviour
{
public void ApplyRecoil(Vector2 recoilDirection, float recoilForce)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(recoilDirection * recoilForce, ForceMode2D.Impulse);
    }
}
