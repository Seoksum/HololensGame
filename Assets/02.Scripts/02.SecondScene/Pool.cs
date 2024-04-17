using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject PoolableObject;
    public int ObjectCount = 10;
    Queue<GameObject> ObjectPool = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ObjectCount; i++)
        {
            CreatePooledObject();
        }
    }

    void CreatePooledObject()
    {
        GameObject bullet = Instantiate(PoolableObject);
        bullet.GetComponent<Poolable>().Init(this);
        bullet.SetActive(false);
        ObjectPool.Enqueue(bullet);
    }

    // Get Object
    public GameObject OnTakeFromPool()
    {
        if (ObjectPool.Count <= 0)
        {
            CreatePooledObject();
        }

        GameObject Object = ObjectPool.Dequeue();
        Object.GetComponent<Poolable>().CleanUp();
        Object.SetActive(true);
        return Object;
    }

    // Back to pool
    public void OnReturnedToPool(GameObject _enqueueObject)
    {
        _enqueueObject.SetActive(false);
        ObjectPool.Enqueue(_enqueueObject);
    }
}
