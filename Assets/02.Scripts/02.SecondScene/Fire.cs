using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public Vector3 originPos;

    public Pool pool;
    
    void Start()
    {
        
    }

    
    public void fireBullet()
    {
        //originPos = firePos.transform.position;
        GameObject pooledObject = pool.Dequeue();
        pooledObject.transform.position = firePos.transform.position;
        pooledObject.transform.Translate(Vector3.forward * 2.5f);

    }
    
}
