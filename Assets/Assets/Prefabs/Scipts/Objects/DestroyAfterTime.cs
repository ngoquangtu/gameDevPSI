using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
   [SerializeField] private float destroyTime;
    void Start()
    {
        Destroy(this.gameObject,destroyTime);
    }

}
