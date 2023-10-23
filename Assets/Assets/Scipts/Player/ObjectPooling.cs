using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    
    public static ObjectPooling instance;
    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool=40;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float timeDestroyBullet=5.0f;
    private void Awake() {
        {
            if(instance==null)
            {
                instance=this;
            }
        }
    }
    void Start()
    {
        for(int i = 0; i < amountToPool; i++) 
        {
            GameObject obj=Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);    
        }
        
    }
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++) 
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                StartCoroutine(DeactivateBulletAfterDelay(pooledObjects[i]));
                return pooledObjects[i];
            }
        }
        return null;
    }
        IEnumerator DeactivateBulletAfterDelay(GameObject bullet)
    {
        yield return new WaitForSeconds(timeDestroyBullet);
        bullet.SetActive(false);
    }
}
