using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    
    public static ObjectPooling instance;
    private List<GameObject> pooledObjects = new List<GameObject>();
    private List<GameObject> pooledhitObjects = new List<GameObject>();
    private int amountToPool=40;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject hitbulletPrefab;
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
            GameObject hitobj=Instantiate(hitbulletPrefab);
            obj.SetActive(false);
            hitobj.SetActive(false);;
            pooledObjects.Add(obj);    
            pooledhitObjects.Add(hitobj);
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
         for(int i = 0; i < pooledhitObjects.Count; i++) 
        {
            if(!pooledhitObjects[i].activeInHierarchy)
            {   
                return pooledhitObjects[i];
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
