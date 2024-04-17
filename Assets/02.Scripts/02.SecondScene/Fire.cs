using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] Transform firePos;
    [SerializeField] Pool pool;

    void Start()
    {
        
    }

    public void FireBullet()
    {
        GameObject pooledObject = pool.OnTakeFromPool();
        pooledObject.transform.position = firePos.transform.position;
    }
    
}
